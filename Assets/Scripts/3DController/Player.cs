using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller3D))]
public class Player : MonoBehaviour {
    //Movement Values
    public float maxJumpHeight;
    public float minJumpHeight;
    public float timeToJumpApex;
    public float accelerationTimeAirborne;
    public float accelerationTimeGrounded;
    public float moveSpeed;
    public float yaw = 5;
    public float pitch = 5;
    public float speedH = 10;
    public float speedV = 10;

    //Calculated values
    public Vector3 velocity;
    public Vector3 prevVelocity;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    float velocityXSmoothing;
    float velocityZSmoothing;
    bool isGrounded;
    float distToGround;

    Controller3D controller;
    Vector2 directionalInput;
    public State state;
    private Animator anim;

    //state machine
    public enum State {
        idle,
        walk,
        glide,
        jump
    }

    // Use this for initialization
    void Start () {
        controller = GetComponent<Controller3D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        distToGround = GetComponent<CapsuleCollider>().bounds.extents.z;

        anim = GetComponent<Animator>();
        state = State.idle;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        prevVelocity = velocity;
        CalculateVelocity();
        controller.Move(velocity * Time.deltaTime, directionalInput);
        isGrounded = IsGrounded();

        if (isGrounded) {
            velocity.y = 0;
            anim.SetBool("isJumping", false);
        }

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    void CalculateVelocity() {
        float targetVelocityX = directionalInput.x * moveSpeed;
        float targetVelocityZ = directionalInput.y * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (isGrounded) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.z = Mathf.SmoothDamp(velocity.z, targetVelocityZ, ref velocityZSmoothing, (isGrounded) ? accelerationTimeGrounded : accelerationTimeAirborne);

        velocity.y += gravity * Time.deltaTime;
        
        //set animation stuff
        if(Mathf.Abs(velocity.x) > 2.0f || Mathf.Abs(velocity.z) > 2.0f) {
            anim.SetBool("isMoving", true);
        } else {
            anim.SetBool("isMoving", false);
        }
    }

    public void SetDirectionalInput(Vector2 input) {
        directionalInput = input;
    }

    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }

    //========================
    //      Inputs
    //========================
    public void OnJumpInputDown() {
        if(isGrounded) {
            state = State.jump;
            anim.SetBool("isJumping", true);
            velocity.y = maxJumpVelocity;
        } 
    }

    public void OnGlideInputDown() {
        velocity.y = -gravity;
        state = State.glide;
        anim.SetBool("isGliding", true);
    }

    public void OnGlideInputUp() {
        anim.SetBool("isGliding", false);
    }

    public void OnJumpInputUp() {
        if(velocity.y > minJumpVelocity) {
            velocity.y = minJumpVelocity;
        }
    }

    //========================
    //      Getters/Setters
    //========================
    public Vector3 GetVelocity() {
        return velocity;
    }
}
