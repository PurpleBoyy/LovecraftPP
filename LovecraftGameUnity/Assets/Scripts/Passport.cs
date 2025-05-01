using UnityEngine;
using UnityEngine.UI;
public class Passport : MonoBehaviour
{

    public GameObject StampImg;
    public GameObject SmallPassport;
    public GameObject BigPassport;
    public Char charScrpit;

    public bool isDocumentValid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPassport();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPassport()
    {
        int passportType = Random.Range(0, 2);

        if (passportType == 1)
        {
            isDocumentValid = true;
            BigPassport.GetComponent<Image>().color = Color.cyan;
            CutSceneManager.Instance.isAllowed = true;
        }
        else
        {
            isDocumentValid = false;
            BigPassport.GetComponent<Image>().color = Color.magenta;
            CutSceneManager.Instance.isAllowed = false;
        }
    }

    public void OpenPassport()
    {
        BigPassport.SetActive(true);
        SmallPassport.SetActive(false);
    }

    public void Stamp()
    {
        StampImg.SetActive(true);

        if (GameManager.Instance.canCharPass)
        {
            StampImg.GetComponent<Image>().color = Color.green;
            charScrpit.Stamped = 2;
        }
        else
        {
            StampImg.GetComponent<Image>().color = Color.red;
            charScrpit.Stamped = 1;
        }
    }
}
