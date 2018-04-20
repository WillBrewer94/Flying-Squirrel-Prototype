using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour {

    public int collectCount;
    private AudioSource audio;
    public Text gemText;
    // Use this for initialization
    void Start () {
        collectCount = 0;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // call when the player collides with a collectable, will increase collectCount
    public void collectObject()
    {
        collectCount++;
        audio.Play();
        gemText.text = collectCount.ToString();
    }
}
