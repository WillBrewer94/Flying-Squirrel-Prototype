using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyCloud : MonoBehaviour {

	public float bounce = 50;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("up");
        other.transform.GetComponent<Rigidbody>().AddForce(0, bounce, 0);
    }

    void OnTriggerStay(Collider other)
    {
		other.transform.GetComponent<Rigidbody>().AddForce(0, bounce, 0);
    }
}
