using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {
    public BoxCollider bc;
    public Canvas canvas;
    public textBoxManager text;
	// Use this for initialization
	void Start () {
        bc = GetComponent<BoxCollider>();
        text = GetComponentInChildren<textBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(bc);
        if (text.talking)
        {
            canvas.enabled = false;
        }
	}
    
    void OnTriggerEnter(Collider other)
    {
        canvas.enabled = true;
        Debug.Log("enter");
    }

    void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
        text.DisableTextBox();
        Debug.Log("exit");
    }
    void OnTriggerStay(Collider other)
    {
        if (text.talking)
        {
            canvas.enabled = false;
        }
    }
}
