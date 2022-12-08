using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject.Find("ButtonPlay").GetComponentInChildren<Text>().text = "PLAY";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
