using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    ParticleSystem particles;
    AudioSource audio2;

    public float spin = 2;
    public float spinLimit = 20;
    public float scale = 0.05f;

    private bool hit = false;

    // Use this for initialization
    void Start () {
        particles = gameObject.GetComponent<ParticleSystem>();
        audio2 = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (hit)
        {
            transform.Rotate(0, spin++, 0);

            transform.localScale -= new Vector3(scale, scale, scale);

            if (spin >= spinLimit)
            {
                Destroy(this.gameObject);
            }
        }
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
                    other.GetComponent<Rigidbody>().AddForce(transform.up * 20);
                    audio2.Play();
                    hit = true;
                }
            }
            
        }
    }
}
