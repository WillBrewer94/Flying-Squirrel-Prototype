using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textManagerFinal : MonoBehaviour {
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
	public Text notDone;
    public Text done;
    public PlayerCollect gemCount;
    public int goal = 1;//change this to more

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
            if ((Input.GetKeyDown("e")))
            {
                currentLine++;
            }
            if (currentLine > endAtLine)
            {
                DisableTextBox();
                
            }
            theText.text = textLines[currentLine];
        } else
        {
            if ((Input.GetKeyDown("e")))
            {
                EnableTextBox();
                reloadScript();
            }
        }
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
	public void reloadScript() {
            if (gemCount.collectCount >= goal)
            {
                textLines = (done.text.Split('\n'));
                endAtLine = textLines.Length - 1;
            }
            else
            {
                textLines = (notDone.text.Split('\n'));
                endAtLine = textLines.Length - 1;
            }
	}
}
