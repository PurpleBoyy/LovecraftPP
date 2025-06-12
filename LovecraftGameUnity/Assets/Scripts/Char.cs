using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Char : MonoBehaviour
{
    public GameObject Passport;
    public GameObject Lightning;
    public Animator anim;
    public SpriteClass Sprites;

    public bool isRandom = true;
    public int nonRand;

    public int Stamped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isRandom)
        {
            StartCoroutine(PassportSpawn());
            GameManager.Instance.currentChar = gameObject.GetComponent<Char>();
        }
        else
        {
            switch (nonRand)
            {
                case 1:
                    StartCoroutine(RelicSpawn());
                    GameManager.Instance.currentChar = gameObject.GetComponent<Char>();
                    break;
                case 2:
                    StartCoroutine(PoliceTalk());
                    GameManager.Instance.currentChar = gameObject.GetComponent<Char>();
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PassportSpawn()
    {
        yield return new WaitForSeconds(3f);
        CutSceneManager.Instance.StartDialogue();
        yield return new WaitForSeconds(1f);
        //var passport =  Instantiate(Passport, passportSpawn.position, passportSpawn.rotation);
        Passport.GetComponent<Passport>().SmallPassport.SetActive(true);
        Passport.transform.parent = GameManager.Instance.Canves.transform;
        Passport.transform.position = CharManager.Instance.PassportSpawn.position;
        Passport.transform.localScale = new Vector3(1, 1, 1);
        Passport.GetComponent<Passport>().SetSymbols();
    }

    IEnumerator RelicSpawn()
    {
        yield return new WaitForSeconds(3f);
        CutSceneManager.Instance.StartCultDialogue();
        yield return new WaitForSeconds(1f);
        //var passport =  Instantiate(Passport, passportSpawn.position, passportSpawn.rotation);
        Passport.GetComponent<Passport>().SmallPassport.SetActive(true);
        Passport.transform.parent = GameManager.Instance.Canves.transform;
        Passport.transform.position = CharManager.Instance.PassportSpawn.position;
        Passport.transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator PoliceTalk()
    {
        Debug.Log("Polis");
        yield return new WaitForSeconds(3f);
        CutSceneManager.Instance.StartPoliceDialogue();
        GameManager.Instance.isPassportStamped = true;
        Stamped = 1;
    }

    public void RecievePassport()
    {
        if (GameManager.Instance.isPassportStamped == true)
        {
            Passport.SetActive(false);
            Passport.transform.parent = gameObject.transform;
            CutSceneManager.Instance.DialogueBox.SetActive(true);
            GameManager.Instance.insanity += 5;
            GameManager.Instance.insanitySlider.value = GameManager.Instance.insanity;

            if (GameManager.Instance.isPassportValid == true)
            {
                

                if (GameManager.Instance.canCharPass == false) // Check if a valid passport is denied
                {


                    if (GameManager.Instance.insanity > 50 && GameManager.Instance.isCult)
                    {
                        CultChangeAnim();
                        CutSceneManager.Instance.StartCultChangeDialogue();
                        GameManager.Instance.RitualButton.SetActive(true);
                    }
                    else
                    {
                        Stamped = 1;
                        CutSceneManager.Instance.isAllowed = false;
                        GameManager.Instance.invalidEntries++;
                        CutSceneManager.Instance.StartRejectDialogue();
                    }
                }
                else
                {
                    Stamped = 2;
                    CutSceneManager.Instance.StartAllowDialogue();
                    if (GameManager.Instance.isCult)
                    {
                        GameManager.Instance.insanity += 5;
                        GameManager.Instance.insanitySlider.value = GameManager.Instance.insanity;
                        GameManager.Instance.cultEntries++;
                    }
                }
            }
            else if (GameManager.Instance.isPassportValid == false)
            {
                if (GameManager.Instance.canCharPass == true) // Check if a invalid passport is accepted
                {
                    Stamped = 2;
                    CutSceneManager.Instance.isAllowed = true;
                    GameManager.Instance.invalidEntries++;
                    CutSceneManager.Instance.StartAllowDialogue();
                    if (GameManager.Instance.isCult)
                    {
                        GameManager.Instance.insanity += 5;
                        GameManager.Instance.insanitySlider.value = GameManager.Instance.insanity;
                        GameManager.Instance.cultEntries++;
                    }
                }
                else
                {
                    Stamped = 1;

                    if (GameManager.Instance.insanity > 50 && GameManager.Instance.isCult)
                    {
                        CultChangeAnim();
                        CutSceneManager.Instance.StartCultChangeDialogue();
                        GameManager.Instance.RitualButton.SetActive(true);
                    }
                    else
                    {
                        CutSceneManager.Instance.StartRejectDialogue();
                    }
                }
            }

            //CutSceneManager.Instance.ContinueDialogue();

            GameManager.Instance.symb.RemoveRange(0, GameManager.Instance.symb.Count);
        }
    }

    public void Walk()
    {
        if (CutSceneManager.Instance.dialogueOver == true && GameManager.Instance.isPassportStamped == true)
        {
            if (Stamped == 1)
            {
                WalkCheck("CharWalkBack");
            }
            else if (Stamped == 2)
            {
                WalkCheck("CharWalkForward");
            }
        }
    }

    void WalkCheck(string walkDir)
    {
        anim.Play(walkDir);
        Passport.SetActive(false);
        Passport.transform.parent = gameObject.transform;

        if (DaysManager.Instance.noOfChecks < 1)
        {
            StartCoroutine(SpawnCharCor());
            DaysManager.Instance.noOfChecks++;
        }
        else
        {
            DaysManager.Instance.EndDay();
        }

    }

    IEnumerator SpawnCharCor()
    {
        yield return new WaitForSeconds(3);
        CharManager.Instance.SpawnChar();
        CutSceneManager.Instance.ResetDialogue();
        GameManager.Instance.isPassportStamped = false;
        Destroy(gameObject);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void CultChangeAnim()
    {
        StartCoroutine(CultChangeCor());
    }

    IEnumerator CultChangeCor()
    {
        CharManager.Instance.Lightning.SetActive(true);
        transform.DOScale(12f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().sprite = Sprites.AllSprites[1];
        transform.DOScale(10, 1);
        yield return new WaitForSeconds(1);
        transform.DOScale(12f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        CharManager.Instance.Lightning.SetActive(false);
        GetComponent<Image>().sprite = Sprites.AllSprites[2];
        transform.DOScale(10, 1);
    }
}
