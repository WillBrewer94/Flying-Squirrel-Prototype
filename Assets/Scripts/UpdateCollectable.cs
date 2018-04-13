using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollectable : MonoBehaviour {

	public float spin = 2;
	public float spinLimit = 20;
	public float scale = 0.05f;

	private bool collected = false;

    void FixedUpdate()
    {
		if (collected) {
			transform.Rotate (0, spin++, 0);

			transform.localScale -= new Vector3(scale, scale, scale);

			if (spin >= spinLimit) {
				Destroy (this.gameObject);
				GameObject player = GameObject.FindGameObjectWithTag ("Player");
				player.GetComponent<PlayerCollect>().collectObject ();
			}
		} else {
			transform.Rotate(0, spin, 0);
		}
    }

    void OnTriggerEnter(Collider c)
    {
        
        // destroys the object when the player collides with it
        // uses the logic from m3
        if (c.attachedRigidbody != null)
        {

            PlayerCollect pc = c.attachedRigidbody.gameObject.GetComponent<PlayerCollect>();
            if (pc != null) {
				collected = true;
            }
        }
    }
	/**
	void OnTriggerStay(Collider c)
	{

		// destroys the object when the player collides with it
		// uses the logic from m3
		if (c.attachedRigidbody != null)
		{
			//Destroy(this.gameObject);
			PlayerCollect pc = c.attachedRigidbody.gameObject.GetComponent<PlayerCollect>();
			if (pc != null) {
				if (spin >= spinLimit) {
					Destroy (this.gameObject);
					pc.collectObject ();
				}
			}
		}
	}
	**/
}
