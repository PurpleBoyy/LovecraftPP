using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour
{
    public GameObject Passport;
    public Animator anim;

    public int Stamped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PassportSpawn());
        GameManager.Instance.currentChar = gameObject.GetComponent<Char>();
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

    public void RecievePassport()
    {
        if (GameManager.Instance.isPassportStamped == true)
        {
            Passport.SetActive(false);
            Passport.transform.parent = gameObject.transform;
            CutSceneManager.Instance.DialogueBox.SetActive(true);

            if(GameManager.Instance.isPassportValid == true && GameManager.Instance.canCharPass == false)// Check if a valid passport is denied
            {
                CutSceneManager.Instance.isAllowed = false;
                CutSceneManager.Instance.lineIndex = CutSceneManager.Instance.RejectedLines[0].pauseIndex;
                CutSceneManager.Instance.charLineIndex = 0;
                GameManager.Instance.invalidEntries++;
            }
            else if (GameManager.Instance.isPassportValid == false && GameManager.Instance.canCharPass == true)// Check if a invalid passport is accepted
            {
                CutSceneManager.Instance.isAllowed = true;
                CutSceneManager.Instance.lineIndex = CutSceneManager.Instance.AllowedLines[0].pauseIndex;
                CutSceneManager.Instance.charLineIndex = 0;
                GameManager.Instance.invalidEntries++;
            }

            CutSceneManager.Instance.ContinueDialogue();

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
}
