using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float rotate = 150f; //how much the player rotates
	public float speed = 10f; //how fast the character moves forward
	public float jump = 10f;
    public float glide = 3f; //how fast the character glides forward
    public bool djump = false; //if the character has jumped in the air
    public float jumpdel = 0; //Measures if the character has jumped recently for gliding
    public State state;

	public LayerMask groundLayers; //what stuff the player can jump on

	private Rigidbody rb;
	private BoxCollider collider;
    private Animator anim;


    //state machine
    public enum State
    {
        idle,
        walk,
        glide,
        jump
    }

	void Awake() {
		rb = GetComponent<Rigidbody> ();
		collider = GetComponent<BoxCollider> ();
        anim = GetComponent<Animator>();
        state = State.idle;
	}

	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotate;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
         if (z != 0 && isGrounded())
        {
            anim.SetBool("isMoving", true);
        } else
        {
            anim.SetBool("isMoving", false);
        }
        //Reset double jump while on the ground
        if (isGrounded())
        {
            djump = false;
        }

        //Increment down the counter to see if the player is trying to glide
        if (jumpdel > 0)
        {
            jumpdel--;
        }

		//Jumping
		if ((isGrounded() || !djump) && Input.GetKeyDown (KeyCode.Space)) {
            state = State.jump;
            anim.SetBool("isJumping", true);
            // double jump
            if (!isGrounded())
            {
                djump = true;
                rb.AddForce(Vector3.up * jump / 2, ForceMode.Impulse);
            } else
            // first jump
            {
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }

            jumpdel = 25;
		} else
        {
            anim.SetBool("isJumping", false);
        }

        //Glide if the space bar is held down
        if (!isGrounded() && Input.GetKey(KeyCode.Space) && jumpdel == 0)
        {
            state = State.glide;
            anim.SetBool("isGliding", true);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * .95f, rb.velocity.z);
        } else
        {
            anim.SetBool("isGliding", false);
        }
	}

	public bool isGrounded() {
		Vector3 begin = collider.bounds.center;
		Vector3 end = new Vector3 (collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z);

		//below uses the begin and end to check the area around player if it is touch the ground layer mask
		return Physics.CheckCapsule(begin, end, collider.bounds.min.y *.5f, groundLayers);
	}
}
