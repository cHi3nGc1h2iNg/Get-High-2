using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEngine.UI.text;

public class scaleText : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Text text;
    private int buttonState = 0;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //buttonState = 0;
        text.GetComponent<RectTransform>().localScale = Vector3.one * 1.2f;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       //buttonState = 1;
       text.GetComponent<RectTransform>().localScale = Vector3.one * 1f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
    }
    

    // Update is called once per frame
    /*void Update()
    {
        
        if (buttonState == 0)
        {
            text.GetComponent<RectTransform>().localScale = Vector3.one * 2f;
            Debug.Log("1.2");
            new WaitForSeconds(1f);
            text.GetComponent<RectTransform>().localScale = Vector3.one * 1f;
            Debug.Log("1");
            new WaitForSeconds(1f);
        }
        if (buttonState == 1)
        {
            
            text.GetComponent<RectTransform>().localScale = Vector3.one * 1f;
        }
    }*/
}
