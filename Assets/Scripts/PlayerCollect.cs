using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {

    public int collectCount;

	// Use this for initialization
	void Start () {
        collectCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // call when the player collides with a collectable, will increase collectCount
    public void collectObject()
    {
        collectCount++;
    }
}
