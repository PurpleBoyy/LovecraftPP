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
    }

    public void RecievePassport()
    {
        Passport.SetActive(false);
        Passport.transform.parent = gameObject.transform;
        CutSceneManager.Instance.DialogueBox.SetActive(true);
        //CutSceneManager.Instance.charLineIndex--;
        CutSceneManager.Instance.ContinueDialogue();
    }

    public void Walk()
    {
        if (CutSceneManager.Instance.dialogueOver == true)
        {
            if (Stamped == 1)
            {
                anim.Play("CharWalkBack");
                Passport.SetActive(false);
                Passport.transform.parent = gameObject.transform;
                StartCoroutine(SpawnCharCor());
            }
            else if (Stamped == 2)
            {
                anim.Play("CharWalkForward");
                Passport.SetActive(false);
                Passport.transform.parent = gameObject.transform;
                StartCoroutine(SpawnCharCor());
            }
        }
    }

    IEnumerator SpawnCharCor()
    {
        yield return new WaitForSeconds(3);
        CharManager.Instance.SpawnChar();
        CutSceneManager.Instance.ResetDialogue();
        Destroy(gameObject);
    }
}
