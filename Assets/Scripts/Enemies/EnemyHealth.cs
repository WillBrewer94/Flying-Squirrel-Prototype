using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.tag == "Player")
        {
            //transform.eulerAngles = new Vector3(0, 0, 90);
            transform.Rotate(Time.deltaTime, 0, 0);
            
            if (other.gameObject.transform.position.y > transform.position.y)
            {
                if (gameObject.GetComponent<Enemy1>().active == true)
                {
                    gameObject.GetComponent<Enemy1>().active = false;
                    particles.Play();
                }
            }
        }
    }
}
