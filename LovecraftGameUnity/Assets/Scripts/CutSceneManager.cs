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
    public bool PaperworkBad;
    public bool dialogueOver;
    public bool isCult;
    public int lineIndex;
    public int DialougeIndex;

    [Header("Lines")]
    public List<DialogueClass> StartLines = new List<DialogueClass>();
    public List<DialogueClass> AllowedLines = new List<DialogueClass>();
    public List<DialogueClass> RejectedLines = new List<DialogueClass>();
    public List<DialogueClass> AskSymbols = new List<DialogueClass>();
    public List<string> CurrentDialouge = new List<string>();

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
        DialougeIndex = Random.Range(0, CurrentDialouge.Count);
        CurrentDialouge = StartLines[DialougeIndex].line;
        ContinueDialogue();
        Debug.Log("startDialogue");
    }

    public void StartAllowDialogue()
    {
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, AllowedLines.Count);
        CurrentDialouge = AllowedLines[DialougeIndex].line;
        ContinueDialogue();
    }

    public void StartRejectDialogue()
    {
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, RejectedLines.Count);
        CurrentDialouge = RejectedLines[DialougeIndex].line;
        ContinueDialogue();
    }

    public void StartSymbolDialouge()
    {
        GameManager.Instance.CheckList.SetActive(false);
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, AskSymbols.Count);
        CurrentDialouge = AskSymbols[DialougeIndex].line;
        ContinueDialogue();
    }

    public void ResetDialogue()
    {
        dialogueOver = false;
        lineIndex = 0;
    }

    public void ContinueDialogue()
    {
        if (CurrentDialouge.Count > lineIndex)
        {

            dialogueTxt.text = CurrentDialouge[lineIndex];
            lineIndex++;
        }
        else
        {
            DialogueBox.SetActive(false);
            lineIndex = 0;

            if (GameManager.Instance.isPassportStamped)
            {
                dialogueOver = true;
                GameManager.Instance.currentChar.Walk();
                Debug.Log("WALkBack");
            }
        }
    }

}
