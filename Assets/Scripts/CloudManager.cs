using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {
    public GameObject cloud;
    public PlayerCollect count;
    int goal = 15;
	// Use this for initialization
	void Start () {
        cloud.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (count.collectCount >= goal)
        {
            cloud.SetActive(true);
        }
	}
}
