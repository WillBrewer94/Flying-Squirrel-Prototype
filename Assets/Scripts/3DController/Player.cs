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
    public int maxJumps = 5;
    int jumps = 0;

    //Calculated values
    public Vector3 velocity;
    public Vector3 prevVelocity;
    float gravity;
    float curGravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    float velocityXSmoothing;
    float velocityZSmoothing;
    bool isGrounded;
    float distToGround;

    Controller3D controller;
    Vector2 directionalInput;

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
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //cache previous velocity
        prevVelocity = velocity;
        CalculateVelocity();
        controller.Move(velocity * Time.deltaTime, directionalInput);

        isGrounded = IsGrounded();
        if (isGrounded) {
            velocity.y = 0;
            jumps = 0;
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

        //Ensure velocity doesn't get crazy high
        if(velocity.y > -50.0f) {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    public void SetDirectionalInput(Vector2 input) {
        directionalInput = input;
    }

    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

    //========================
    //      Inputs
    //========================
    public void OnJumpInputDown() {
        if(isGrounded || jumps < maxJumps) {
            velocity.y = maxJumpVelocity;
            jumps++;
        } 
    }

    public void OnJumpInputHold() {
        //Check if velocity is decreasing (moving down)
        if(velocity.y < 0.0f) {
            velocity.y = 0;
        }
    }

    public void OnJumpInputUp() {
        if(velocity.y > minJumpVelocity) {
            //velocity.y = minJumpVelocity;
        }
    }

    //========================
    //      Getters/Setters
    //========================
    public Vector3 GetVelocity() {
        return velocity;
    }
}
