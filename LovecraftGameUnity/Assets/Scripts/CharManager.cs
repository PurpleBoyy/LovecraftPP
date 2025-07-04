using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharManager : MonoBehaviour
{
    public static CharManager Instance;

    public List<SpriteClass> CharSpritesLists = new List<SpriteClass>();
    public GameObject PortMask;
    public GameObject Lightning;
    public GameObject CharObject;
    public GameObject CultPersonObject;
    public GameObject PolicePersonObject;
    public Transform PassportSpawn;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPoliceChar();
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
        int charSprite = Random.Range(0, CharSpritesLists.Count);
        Debug.Log(charSprite);
        obj.GetComponent<Image>().sprite = CharSpritesLists[charSprite].AllSprites[0];
        obj.GetComponent<Char>().Sprites = CharSpritesLists[charSprite];
        Debug.Log("SpawnChar");
    }

    public void SpawnCultChar()
    {
        var obj = Instantiate(CultPersonObject, transform.position, transform.rotation);
        obj.transform.parent = PortMask.transform;
        obj.transform.localScale = new Vector3(10, 10, 10);
    }

    public void SpawnPoliceChar()
    {
        var obj = Instantiate(PolicePersonObject, transform.position, transform.rotation);
        obj.transform.parent = PortMask.transform;
        obj.transform.localScale = new Vector3(10, 10, 10);
    }
}

[System.Serializable]
public class SpriteClass
{
    public List<Sprite> AllSprites = new List<Sprite>();
}
