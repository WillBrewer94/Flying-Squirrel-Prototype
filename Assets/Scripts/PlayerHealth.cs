using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    int health = 3;
    public HealthController healthController;
    public float lastHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == "Enemy")
        {
            Debug.Log("enemy");
            if (Time.time > lastHit + 2)
            {
                Debug.Log("health");
                healthController.lowerHealth();
                health--;
                lastHit = Time.time;
            }
        }
    }
}
