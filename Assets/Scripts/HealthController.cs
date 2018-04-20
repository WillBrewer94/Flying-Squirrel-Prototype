using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    public RawImage hc1;
    public RawImage hc2;
    public RawImage hc0;
    public Texture empty;
    public Texture full;
    int health = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.anyKeyDown)
        //{
            //lowerHealth();
        //}
	}

    public void lowerHealth()
    {
        if (health == 3)
        {
            hc2.texture = empty;
        } else if (health == 2)
        {
            hc1.texture = empty;
        } else
        {
            hc0.texture = empty;
        }
        health--;
    }
    public void raiseHealth()
    {
        if (health == 2)
        {
            hc2.texture = full;
        }
        else if (health == 1)
        {
            hc1.texture = full;
        }
        health++;
    }
    public void resetHealth()
    {
        hc2.texture = full;
        hc1.texture = full;
        hc0.texture = full;
        health = 3;
    }
}
