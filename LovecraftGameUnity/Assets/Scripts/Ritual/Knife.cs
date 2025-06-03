using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Knife : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector3 mousePos;
    float lastX;
    public float bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (lastX != mousePos.x - transform.position.x)
        {
            lastX = mousePos.x - transform.position.x;
            bar += Mathf.Abs(lastX);
            Debug.Log(lastX);
        }

        if(bar > 500)
        {
            Destroy(HandChopScript.Instance.Fingers[HandChopScript.Instance.FingIndex]);
            Destroy(gameObject);
            HandChopScript.Instance.isCutting = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2((Camera.main.ScreenToWorldPoint(Input.mousePosition).x + mousePos.x),transform.position.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
