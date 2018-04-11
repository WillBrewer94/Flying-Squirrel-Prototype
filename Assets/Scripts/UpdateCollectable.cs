using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.Rotate(0, 1, 0);
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
                Destroy(this.gameObject);
                pc.collectObject();
            }
        }
    }
}
