using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class HandChopScript : MonoBehaviour
{
    public static HandChopScript Instance;

    public GameObject Knife;
    public List<GameObject> Fingers = new List<GameObject>();
    public int FingIndex;
    public bool isCutting;

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

    public void EndRitual()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level");

    }

    public void StartCutting(int i)
    {
        if (isCutting == false)
        {
            Vector3 pos = new Vector3(Fingers[i].transform.position.x, Fingers[i].transform.position.y - 0.45f, Fingers[i].transform.position.z);
            Instantiate(Knife, pos, transform.rotation, transform);
            FingIndex = i;
            isCutting = true;
        }
    }
}
