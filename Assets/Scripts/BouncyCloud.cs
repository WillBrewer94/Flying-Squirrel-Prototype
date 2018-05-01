using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCloud : MonoBehaviour {

	public float bounce = 70;
	public float bounceStay = 20;
	private float bounceOrig;

	private Vector3 jumpVec;
	private Vector3 jumpVecStay;

	void Awake() {
		jumpVec = new Vector3 (0, bounce, 0);
		bounceOrig = bounceStay;
	}

	/**
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("up");
		Player p = other.attachedRigidbody.gameObject.GetComponent<Player>();
		if (p != null) {
			p.SetVelocity(jumpVec);
		}
    }
    */


    void OnTriggerStay(Collider other)
    {
		bounceStay+=3;
		jumpVecStay = new Vector3 (0, bounceStay, 0);
		Player p = other.attachedRigidbody.gameObject.GetComponent<Player>();
		if (p != null) {
			p.SetVelocity(jumpVecStay);
		}
    }

	void OnTriggerExit(Collider other)
	{
		bounceStay = bounceOrig;
	}
    
}
