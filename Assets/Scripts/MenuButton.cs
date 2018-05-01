using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButton : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadGame()
    {
        SceneManager.LoadScene("The Game");
    }
    public void quit()
    {
        Application.Quit();
    }
}
