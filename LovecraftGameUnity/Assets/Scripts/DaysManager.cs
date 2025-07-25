using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DaysManager : MonoBehaviour
{
    public static DaysManager Instance;

    public GameObject EndDayObj;
    public GameObject EndWeekObj;
    public GameObject RitualObj;
    public GameObject MainObj;
    public GameObject NewsPaper;

    public TextMeshProUGUI SavingsTxt;
    public TextMeshProUGUI SalaryTxt;
    public TextMeshProUGUI RentTxt;
    public TextMeshProUGUI FoodTxt;
    public TextMeshProUGUI PenaltyTxt;
    public TextMeshProUGUI CultTxt;
    public Image FoodButtonImg;
    public TextMeshProUGUI TotalTxt;

    public int noOfChecks;
    public int totalNoOfChecks;
    public int noOfDays;
    public int totalNoOfDays;

    public bool food;

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

    public void FoodButton()
    {
        food = !food;

        if (food)
        {
            FoodButtonImg.color = Color.red;
        }
        else
        {
            FoodButtonImg.color = Color.grey;
        }
    }

    public void EndDay()
    {
        EndDayObj.SetActive(true);
        SavingsTxt.text = "Savings: " + GameManager.Instance.playerSavings;
        SalaryTxt.text = "Salary: " + 30;
        FoodTxt.text = "Food: " + 20;
        PenaltyTxt.text = "Penalty: " + GameManager.Instance.invalidEntries *5;
        CultTxt.text = "Cult Bonus: " + GameManager.Instance.cultEntries *15;

        GameManager.Instance.playerSavings += 30; //salary
        GameManager.Instance.playerSavings -= 20; //rent
        GameManager.Instance.playerSavings -= GameManager.Instance.invalidEntries * 5; //penalty
        GameManager.Instance.playerSavings += GameManager.Instance.cultEntries * 15; //cultMoney

        if (food)
        {
            FoodTxt.text = "Food: " + 20;
            GameManager.Instance.playerSavings -= 20; //food
        }
        else
        {
            FoodTxt.text = "Food: " + 0;
        }


        TotalTxt.text = "Savings: " + GameManager.Instance.playerSavings;
    }

    public void NewsaperOpen()
    {
        NewsPaper.SetActive(true);
    }

    public void StartNextDay()
    {
        NewsPaper.SetActive(false);
        noOfChecks = 0;
        noOfDays++;

        switch (noOfDays)
        {
            case 1:
                EndDayObj.SetActive(false);
                CutSceneManager.Instance.ResetDialogue();
                GameManager.Instance.isPassportStamped = false;
                GameManager.Instance.invalidEntries = 0;
                GameManager.Instance.cultEntries = 0;
                CharManager.Instance.SpawnPoliceChar();
                break;
            case 2:
                EndDayObj.SetActive(false);
                CutSceneManager.Instance.ResetDialogue();
                GameManager.Instance.isPassportStamped = false;
                GameManager.Instance.invalidEntries = 0;
                GameManager.Instance.cultEntries = 0;
                CharManager.Instance.SpawnCultChar();
                break;

            default:
                EndDayObj.SetActive(false);
                CutSceneManager.Instance.ResetDialogue();
                GameManager.Instance.isPassportStamped = false;
                GameManager.Instance.invalidEntries = 0;
                GameManager.Instance.cultEntries = 0;
                CharManager.Instance.SpawnChar();
                break;
        }

        if(noOfDays >= totalNoOfDays)
        {
            EndWeekObj.SetActive(true);
        }
        else
        {
           
        }
    }

    public void Ritual()
    {
        GameManager.Instance.currentChar.GetComponent<Char>().Die();
        RitualObj.SetActive(true);
        MainObj.SetActive(false);
    }


}
