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
    public List<DialogueClass> CultPersonLines = new List<DialogueClass>();
    public List<DialogueClass> CultChangeLines = new List<DialogueClass>(); // Morphing into a monster
    public List<DialogueClass> PolicePersonLines = new List<DialogueClass>();
    public List<string> CurrentDialouge = new List<string>();

    [Header("CheckLines")]
    public List<DialogueClass> SymbolsCheck = new List<DialogueClass>();
     public List<DialogueClass> PassportCheck = new List<DialogueClass>();
     public List<DialogueClass> CountryCheck = new List<DialogueClass>();
     public List<DialogueClass> DateCheck = new List<DialogueClass>();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void StartCultDialogue()
    {
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, CultPersonLines.Count);
        CurrentDialouge = CultPersonLines[DialougeIndex].line;
        ContinueDialogue();
        Debug.Log("startCultDialogue");
    }

    public void StartPoliceDialogue()
    {
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, PolicePersonLines.Count);
        CurrentDialouge = PolicePersonLines[DialougeIndex].line;
        ContinueDialogue();
        Debug.Log("startPolisDialogue");
    }

    public void StartCultChangeDialogue()
    {
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, CultChangeLines.Count);
        CurrentDialouge = CultChangeLines[DialougeIndex].line;
        ContinueDialogue();
        Debug.Log("startCultDialogue");
    }

    #region Passport
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
    #endregion

    #region Symbols

    public void StartSymbolCheckDialouge()
    {
        GameManager.Instance.CheckList.SetActive(false);
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, SymbolsCheck.Count);
        CurrentDialouge = SymbolsCheck[DialougeIndex].line;
        ContinueDialogue();
    }

    public void StartPassportCheckDialouge()
    {
        GameManager.Instance.CheckList.SetActive(false);
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, PassportCheck.Count);
        CurrentDialouge = PassportCheck[DialougeIndex].line;
        ContinueDialogue();
    }

    public void StartCountryCheckDialouge()
    {
        GameManager.Instance.CheckList.SetActive(false);
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, CountryCheck.Count);
        CurrentDialouge = CountryCheck[DialougeIndex].line;
        ContinueDialogue();
    }

    public void StartDateCheckDialouge()
    {
        GameManager.Instance.CheckList.SetActive(false);
        DialogueBox.SetActive(true);
        DialougeIndex = Random.Range(0, DateCheck.Count);
        CurrentDialouge = DateCheck[DialougeIndex].line;
        ContinueDialogue();
    }
    #endregion

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
            else
            {
                if(CurrentDialouge == StartLines[DialougeIndex].line)
                {
                    GameManager.Instance.currentChar.SpawnPassportChar();
                    Debug.Log("SpawnPassport");
                }
            }
        }
    }

    public void CultManBack()
    {
        dialogueOver = true;
        GameManager.Instance.isPassportStamped = true;
        GameManager.Instance.currentChar.Stamped = 1;
        GameManager.Instance.currentChar.Walk();
        Debug.Log("CultBack");
    }

}
