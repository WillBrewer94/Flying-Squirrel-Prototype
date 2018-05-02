using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textBoxManager : MonoBehaviour {
	public TextAsset textFile;
	public string[] textLines;
	public GameObject textBox;
	public Text theText;
	public int currentLine;
	public int endAtLine = 0;
	public bool isTextActive;
	//public ButtonManager theButton;
	public TextAsset textFortunes;
	bool end = false;
	public Text press;

    public bool talking = false;
	// Use this for initialization
	void Start () {
		isTextActive = false;
		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(currentLine);
        if (talking)
        {
            //if ((Input.GetKeyDown("e")))
            //{
                //currentLine++;
            //}
            if (currentLine > endAtLine)
            {
                DisableTextBox();
                
            }
            theText.text = textLines[currentLine];
        }// else
       // {
            //if ((Input.GetKeyDown("e")))
            //{
                //EnableTextBox();
            //}
        //}
    }
	public void EnableTextBox() {
		isTextActive = true;
		textBox.SetActive(true);
        talking = true;
        currentLine = 0;
		//playerControls.talking = true;
	}
	public void DisableTextBox() {
		isTextActive = false;
		textBox.SetActive(false);
        talking = false;
        //playerControls.talking = false;
    }
	public void ReloadScript(TextAsset text) {
		if (text != null) {
			textFile = text;
			textLines = new string[1];
			textLines = (text.text.Split('\n'));
			endAtLine = textLines.Length - 1;
		}
	}
    public void advanceScript()
    {
        if (talking)
        {
            currentLine++;
        }
        else
        {
            EnableTextBox();
        }
    }
}
