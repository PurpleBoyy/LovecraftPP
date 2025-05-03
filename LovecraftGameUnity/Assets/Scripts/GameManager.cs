using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Canves;
    public Char currentChar;
    public bool canCharPass;
    public bool isPassportStamped;
    public bool isPassportValid;
    public int playerSavings;
    public int invalidEntries;
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

    public void AllowStamp()
    {
        canCharPass = true;
    }

    public void DenyStamp()
    {
        canCharPass = false;
    }


}
