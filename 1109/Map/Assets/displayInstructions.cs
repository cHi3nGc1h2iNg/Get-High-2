using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayInstructions : MonoBehaviour
{
    public GameObject Junkie;
    public GameObject Instructions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (0 < Junkie.transform.position.x && Junkie.transform.position.x< 20 && 0 < Junkie.transform.position.z && Junkie.transform.position.z < 20)
        {
            Instructions.gameObject.SetActive(true);
            Debug.Log(true);
        }
        else
        {
            Instructions.gameObject.SetActive(false);
            Debug.Log(false);
        }
    }
}
