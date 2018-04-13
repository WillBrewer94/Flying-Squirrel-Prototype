using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCloud : MonoBehaviour {

	public float bounce = 50;
	public float bounceStay = 5;

	private Vector3 jumpVec;
	private Vector3 jumpVecStay;

	void Awake() {
		jumpVec = new Vector3 (0, bounce, 0);
		jumpVecStay = new Vector3 (0, bounceStay, 0);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("up");
		Player p = other.attachedRigidbody.gameObject.GetComponent<Player>();
		if (p != null) {
			p.SetVelocity(jumpVec);
		}
    }


    void OnTriggerStay(Collider other)
    {
		Player p = other.attachedRigidbody.gameObject.GetComponent<Player>();
		if (p != null) {
			p.SetVelocity(jumpVecStay);
		}
    }
    
}
