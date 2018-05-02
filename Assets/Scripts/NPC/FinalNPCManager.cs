using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalNPCManager : MonoBehaviour {

    public TextAsset textFile;
    public string[] notDoneText;
    public string[] doneText;
    public GameObject textBox;
    public Text theText;
    public int currentLine;
    public int endAtLine = 0;
    public bool isTextActive;
    //public ButtonManager theButton;
    public TextAsset textFortunes;
    bool end = false;
    public TextAsset notDone;
    public TextAsset done;
    public PlayerCollect gemCount;
    public int goal = 1;//change this to more

    public bool talking = false;
    // Use this for initialization

    void Awake()
    {
        Start();
    }
    void Start()
    {
        /*isTextActive = false;
        if (textFile != null)
        {
            textLines = (notDone.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }*/
        doneText = (done.text.Split('\n'));
        notDoneText = (notDone.text.Split('\n'));
        endAtLine = notDoneText.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
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
            if (gemCount.collectCount >= goal)
            {
                theText.text = doneText[currentLine];
            } else
            {
                theText.text = notDoneText[currentLine];
            }
        }
        else
        {
            if ((Input.GetKeyDown("e")))
            {
                EnableTextBox();
                reloadScript();
            }
        }
    }
    public void EnableTextBox()
    {
        isTextActive = true;
        textBox.SetActive(true);
        talking = true;
        currentLine = 0;
        //playerControls.talking = true;
        reloadScript();
    }
    public void DisableTextBox()
    {
        isTextActive = false;
        textBox.SetActive(false);
        talking = false;
        //playerControls.talking = false;
    }
    public void reloadScript()
    {
        if (gemCount.collectCount >= goal)
        {
            endAtLine = doneText.Length - 1;
        }
        else
        {
            endAtLine = notDoneText.Length - 1;
        }
    }
}
