using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3D : MonoBehaviour {
    public GameObject cameraRef;

	// Use this for initialization
	void Start () {
       
	}

    public void Move(Vector3 moveAmount, Vector2 dirInput, Vector2 camInput) {
        //cross product
        transform.Translate(moveAmount);
        transform.rotation = Quaternion.Euler(0, cameraRef.transform.eulerAngles.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
