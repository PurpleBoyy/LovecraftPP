using UnityEngine;
using UnityEngine.UI;
public class Passport : MonoBehaviour
{

    public GameObject StampImg;
    public GameObject SmallPassport;
    public GameObject BigPassport;
    public Char charScrpit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
