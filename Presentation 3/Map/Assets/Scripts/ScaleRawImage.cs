using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScaleRawImage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public RawImage image;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //buttonState = 0;
        image.GetComponent<RectTransform>().localScale = Vector3.one * 1.2f;
        Debug.Log("pointerEnter");
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       //buttonState = 1;
       image.GetComponent<RectTransform>().localScale = Vector3.one * 1f;
       Debug.Log("pointerExit");
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
