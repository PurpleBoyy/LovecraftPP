using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance;


    [Header("DialogueBox")]

    public TextMeshProUGUI dialogueTxt;
    public GameObject DialogueBox;
    public bool isAllowed;
    public bool dialogueOver;
    public bool dialoguePause;
    public int rejPassportPause;
    public int allowPassportPause;
    public int lineIndex;
    public int charLineIndex;

    [Header("Lines")]
    public List<DialogueList> RejectedLines = new List<DialogueList>();
    public List<DialogueList> AllowedLines = new List<DialogueList>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        DialogueBox.SetActive(true);
        ContinueDialogue();
    }

    public void ResetDialogue()
    {
        dialogueOver = false;
        dialoguePause = false;
        rejPassportPause = 2;
        allowPassportPause = 1;
        charLineIndex = 0;
        lineIndex = 0;
    }

    public void ContinueDialogue()
    {
        if (isAllowed)
        {
            if (lineIndex < AllowedLines[0].Dialogue.Count)
            {
              dialogueTxt.text = AllowedLines[0].Dialogue[lineIndex].line[charLineIndex];

               if (charLineIndex < AllowedLines[0].Dialogue[lineIndex].line.Count - 1)
               {
                 charLineIndex++;
               }
              else
               {
                 charLineIndex = 0;
                 lineIndex++;
               }
            }
            else
            {
                dialogueOver = true;
                DialogueBox.SetActive(false);
                GameManager.Instance.currentChar.Walk();
            }

            if (allowPassportPause + 1 == lineIndex && dialoguePause == false)
            {
                DialogueBox.SetActive(false);
                lineIndex--;
                dialoguePause = true;
            }

        }
        else
        {
            if (lineIndex < RejectedLines[0].Dialogue.Count)
            {

               dialogueTxt.text = RejectedLines[0].Dialogue[lineIndex].line[charLineIndex];

               if (charLineIndex < RejectedLines[0].Dialogue[lineIndex].line.Count - 1)
               {
                  charLineIndex++;
               }
              else
               {
                  charLineIndex = 0;
                  lineIndex++;
               }

            }
            else
            {
                dialogueOver = true;
                DialogueBox.SetActive(false);
                GameManager.Instance.currentChar.Walk();
            }

            if (rejPassportPause + 1 == lineIndex && dialoguePause == false)
            {
                DialogueBox.SetActive(false);
                lineIndex--;
                dialoguePause = true;
            }
        }

    }
}
