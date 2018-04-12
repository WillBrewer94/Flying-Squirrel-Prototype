using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("up");
        other.transform.GetComponent<Rigidbody>().AddForce(0, 50, 0);
    }

    void OnTriggerStay(Collider other)
    {
		other.transform.GetComponent<Rigidbody>().AddForce(0, 50, 0);
    }
}
