using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollectable : MonoBehaviour {
	public float spin = 2;
	public float spinCollect = 5;
	public float timer = 100;

	private bool collected = false;


    void FixedUpdate()
    {
		if (collected) {
			transform.Rotate (0, spin++, 0);
		} else {
			transform.Rotate (0, spin, 0);
		}
    }

    void OnTriggerEnter(Collider c)
    {
        
        // destroys the object when the player collides with it
        // uses the logic from m3
        if (c.attachedRigidbody != null)
        {
            //Destroy(this.gameObject);
            PlayerCollect pc = c.attachedRigidbody.gameObject.GetComponent<PlayerCollect>();
            if (pc != null) {
				collected = true;
            }
        }
    }

	void OnTriggerStay(Collider c)
	{

		// destroys the object when the player collides with it
		// uses the logic from m3
		if (c.attachedRigidbody != null)
		{
			//Destroy(this.gameObject);
			PlayerCollect pc = c.attachedRigidbody.gameObject.GetComponent<PlayerCollect>();
			if (pc != null) {
				if (spin >= spinCollect) {
					Destroy(this.gameObject);
					pc.collectObject();
				}
			}
		}
	}
}
