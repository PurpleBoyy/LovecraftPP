using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Passport : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject StampImg;
    public GameObject SmallPassport;
    public GameObject BigPassport;
    public GameObject Symbols;
    public Char charScrpit;
    public TextMeshProUGUI invalidReason;

    public int rand;

    public bool isDocumentValid;
    Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPassport();

        rand = Random.Range(0, 101);

        if (rand > 50)
        {
            Symbols.SetActive(true);
            GameManager.Instance.isCult = true;
            Debug.Log("CULT");
        }
        else
        {
            GameManager.Instance.isCult = false;
        }
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
            GameManager.Instance.isPassportValid = true;
            invalidReason.enabled = false;
        }
        else
        {
            isDocumentValid = false;
            BigPassport.GetComponent<Image>().color = Color.magenta;
            CutSceneManager.Instance.isAllowed = false;
            GameManager.Instance.isPassportValid = false;

            int reason = Random.Range(0, 3);

            switch (reason)
            {
                case 0:
                    invalidReason.text = "Country";
                    GameManager.Instance.invalidReason = invalidReason.text;
                    break;
                case 1:
                    invalidReason.text = "Date";
                    GameManager.Instance.invalidReason = invalidReason.text;
                    break;
                case 2:
                    invalidReason.text = "Pic";
                    GameManager.Instance.invalidReason = invalidReason.text;
                    break;
            }
        }

    }

    public void CultManBack()
    {
        GameManager.Instance.LightButton.SetActive(true);
        CutSceneManager.Instance.CultManBack();
    }

    public void SetSymbols()
    {
        if (rand > 0)
        {
            for (int i = 0; i < GameManager.Instance.symb.Count; i++)
            {
                GameManager.Instance.symb[i].Light = GameManager.Instance.Light;
                Debug.Log("SETLIGHT" + i);
            }
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

        GameManager.Instance.isPassportStamped = true;
    }


    #region Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
    #endregion
}
