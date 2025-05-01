using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharManager : MonoBehaviour
{
    public static CharManager Instance;

    public List<Sprite> CharSprites = new List<Sprite>();
    public GameObject PortMask;
    public GameObject CharObject;
    public Transform PassportSpawn;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnChar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChar()
    {
        var obj = Instantiate(CharObject, transform.position, transform.rotation);
        obj.transform.parent = PortMask.transform;
        obj.transform.localScale = new Vector3(10, 10, 10);
        int charSprite = Random.Range(0, CharSprites.Count);
        Debug.Log(charSprite);
        obj.GetComponent<Image>().sprite = CharSprites[charSprite];
    }
}
