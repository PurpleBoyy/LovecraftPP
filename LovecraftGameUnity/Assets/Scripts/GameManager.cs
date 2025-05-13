using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Canves;
    public GameObject Light;

    public List<CultSymbol> symb = new List<CultSymbol>();

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

    public void LightSwitch()
    {
        if (Light.activeSelf)
        {
            Light.SetActive(false);
        }
        else
        {
            Light.SetActive(true);

            if(symb.Count > 0)
            {
                for (int i = 0; i < symb.Count; i++)
                {
                    symb[i].Light = Light;
                }
            }
        }
    }

}
