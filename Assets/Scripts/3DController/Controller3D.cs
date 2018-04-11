using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Move(Vector3 moveAmount, Vector2 input) {
        transform.Translate(moveAmount);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
