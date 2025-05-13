using UnityEngine;
using UnityEngine.UI;

public class CultSymbol : MonoBehaviour
{
    public GameObject Light;
    public Image img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.symb.Add(this);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Light != null)
        {
            if (Vector2.Distance(transform.position, Light.transform.position) < 1)
            {
                img.enabled = true;
            }
            else
            {
                img.enabled = false;
            }
        }

        //Debug.Log(Vector2.Distance(transform.position, Light.transform.position));
    }
}
