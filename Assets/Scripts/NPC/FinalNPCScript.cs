using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNPCScript : MonoBehaviour {

    public BoxCollider bc;
    public Canvas canvas;
    public FinalNPCManager text;
    // Use this for initialization
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        text = GetComponentInChildren<FinalNPCManager>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        text.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
        text.DisableTextBox();
        Debug.Log("exit");
        text.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (text.talking)
        {
            canvas.enabled = false;
        }
    }
}
