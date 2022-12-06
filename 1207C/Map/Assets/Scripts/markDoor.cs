using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markDoor : MonoBehaviour
{
    public GameObject door01_low;
    public GameObject door03_low;
    private GameObject junkie;
    public Material markedDoor;
    public Material V1;
    private float dist;
    private bool markCnt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        junkie = GameObject.Find("Junkie");
        dist = Vector3.Distance(door03_low.transform.position,junkie.transform.position);
        if (dist <= 2f && Input.GetKeyDown("e"))
        {
            if (markCnt == false)
            {
                door01_low.GetComponent<Renderer>().material = markedDoor;
                door03_low.GetComponent<Renderer>().material = markedDoor;
                markCnt = true;
            }
            else
            {
                door01_low.GetComponent<Renderer>().material = V1;
                door03_low.GetComponent<Renderer>().material = V1;
                markCnt =false;
            }
            
        }
    }
}
