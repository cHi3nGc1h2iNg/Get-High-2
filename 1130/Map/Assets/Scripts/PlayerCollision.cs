using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    private int cashCnt = 0;
    public GameObject TextCashCount;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Cash")
        {
            Destroy(col.gameObject);
            cashCnt ++;
            TextCashCount.GetComponent<Text>().text = "$: " + cashCnt.ToString();
            //GameObject.Find("CashCount").GetComponentInChildren<Text>().Text = "$: " + cashCnt.ToString();
        }
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
