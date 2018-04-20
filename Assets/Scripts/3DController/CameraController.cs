using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject playerRef;
    public float rotateSpeed;
    public float height = 0;
    public float distance = 10;

    private Vector2 cameraInput;
    private Vector3 offsetX;
    private Vector3 offsetY;


	// Use this for initialization
	void Start () {
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);
    }
	
	// Update is called once per frame
	void Update () {
        offsetX = Quaternion.AngleAxis(cameraInput.x * rotateSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(cameraInput.y * rotateSpeed, Vector3.right) * offsetY;
        transform.position = playerRef.transform.position + offsetX;
        transform.LookAt(playerRef.transform);
	}

    public void SetCameraDirectionalInput(Vector2 input) {
        cameraInput = input;
    }
}
