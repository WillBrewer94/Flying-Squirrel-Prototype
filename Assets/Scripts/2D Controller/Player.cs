using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
    //Split Player Prefab
    public GameObject splitPlayer;

    //Movement Values
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;
	public float moveSpeed = 6;
    public float playerDeltaTime;
	
    Vector3 velocity;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    bool wallSliding;
    int wallDirX;
    float velocityXSmoothing;

    public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    
    Controller2D controller;
	Vector2 directionalInput;
    SpriteRenderer sprt;
    Animator anim;

    //Player State Management
    PlayerState playerState;
    Vector2 neutralColSize;
    Vector2 stealthColSize;
    Vector2 stealthPosOffset;

    enum PlayerState {
        NEUTRAL,
        STEALTH
    }

    void Start() {
		controller = GetComponent<Controller2D> ();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);

        neutralColSize = GetComponent<BoxCollider2D>().size;
        stealthColSize = new Vector2(neutralColSize.x, neutralColSize.y / 2);
        stealthPosOffset = new Vector2(0, (neutralColSize.y - stealthColSize.y) / 2);
    }

	void Update() {
        //Delta Time Adjustments
        playerDeltaTime = Time.deltaTime;

        CalculateVelocity ();
		HandleWallSliding ();
		controller.Move (velocity * Time.deltaTime, directionalInput);

		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}

        //Animation Stuff
        /*
        anim.SetFloat("Speed", Mathf.Abs(velocity.x));
        if(velocity.x > 0.05f) {
            sprt.flipX = false;
        } else if(velocity.x < -0.05f) {
            sprt.flipX = true;
        }*/
	}

    void HandleWallSliding() {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;

        if((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
            wallSliding = true;

            if(velocity.y < -wallSlideSpeedMax) {
                velocity.y = -wallSlideSpeedMax;
            }

            if(timeToWallUnstick > 0) {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if(directionalInput.x != wallDirX && directionalInput.x != 0) {
                    timeToWallUnstick -= Time.deltaTime;
                } else {
                    timeToWallUnstick = wallStickTime;
                }
            } else {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    void CalculateVelocity() {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }

    public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
	}


    //=========================
    //         Inputs 
    //=========================

    public void OnJumpInputDown() {
		if (wallSliding) {
			if (wallDirX == directionalInput.x) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (directionalInput.x == 0) {
                velocity.x = -wallDirX * wallJumpOff.x;
				velocity.y = wallJumpOff.y;
            }
			else {
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
			}
		}

		if (controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				if (directionalInput.x != -Mathf.Sign (controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
				}
			} else {
				velocity.y = maxJumpVelocity;
			}
		}
	}

	public void OnJumpInputUp() {
		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}

    public void OnAbility1InputDown() {
        /*if(playerState == PlayerState.NEUTRAL) {
            //Set size of box collider, change state
            playerState = PlayerState.STEALTH;
            GetComponent<BoxCollider2D>().size = stealthColSize;
            GetComponent<BoxCollider2D>().offset = -stealthPosOffset;
            controller.CalculateRaySpacing();
            moveSpeed = 3;
        } else {
            //Set size of box collider to default, change state
            playerState = PlayerState.NEUTRAL;
            GetComponent<BoxCollider2D>().size = neutralColSize;
            GetComponent<BoxCollider2D>().offset = Vector2.zero;
            controller.CalculateRaySpacing();
            moveSpeed = 6;
        }*/
    }

    public void OnAbility1InputUp() {
        //Check Player Type
        if(GetComponent<SplitPlayerInput>()) {
            GameObject mainPlayer = GameObject.FindGameObjectWithTag("MainPlayer");
            if(mainPlayer) {
                mainPlayer.GetComponent<PlayerInput>().enabled = true;
            }

            Destroy(gameObject);
        } else {
            //Split player
            //Grab Player Position
            Vector3 pos = gameObject.transform.position;

            //Instantiate two smaller players with different PlayerInput scripts
            GameObject SplitOne = Instantiate<GameObject>(splitPlayer);
            GameObject SplitTwo = Instantiate<GameObject>(splitPlayer);

            SplitOne.GetComponent<SplitPlayerInput>().CreateWithSplitOneBindings();
            SplitTwo.GetComponent<SplitPlayerInput>().CreateWithSplitTwoBindings();

            //Check for placement
            SplitOne.transform.position = new Vector3(pos.x + 2, pos.y, pos.z);
            SplitTwo.transform.position = new Vector3(pos.x - 2, pos.y, pos.z);

            //Disable main player and set animation state
            GetComponent<PlayerInput>().enabled = false;
        }
    }

    public void OnAbility2InputDown() {

    }

    public void OnAbility2InputUp() {
        Debug.Log(GetComponent<PlayerInput>().GetPlayerType());
    }

    //Reroll Prototype Methods
    /*public void AttackChainWindowStart() {
        anim.SetBool("WaitForNextAttack", true);
    }

    public void AttackChainWindowEnd() {
        anim.SetBool("WaitForNextAttack", false);
    }

    public void OnAbility1InputDown() {
        Debug.Log("Attack");

        bool waitForNextAttack = anim.GetBool("WaitForNextAttack");

        if(!waitForNextAttack) {
            anim.SetTrigger("StartAttack");
            
        } else {
            anim.SetTrigger("TriggerNextAttack");
        }
    }
    
    public void OnRerollInputDown() {
        Debug.Log("Reroll");
    }

    public void OnRerollInputUp() {

    }*/
}
