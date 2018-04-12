using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : MonoBehaviour {
	public static int gems;

	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
		gems = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Gems: " + gems;
	}
}
