using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    int health = 3;
    public HealthController healthController;
    public float lastHit;
    public GameObject respawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            this.transform.parent.position = respawn.transform.position;
            health = 3;
            healthController.resetHealth();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Enemy1>().active == true)
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
        } else if (other.tag == "DeathBox")
        {
            healthController.lowerHealth();
            health--;
            lastHit = Time.time;
            this.transform.parent.position = respawn.transform.position;
        }
    }
}
