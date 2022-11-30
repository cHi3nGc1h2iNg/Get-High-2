using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSpinningRoom2 : MonoBehaviour
{
    public CharacterController controller;
    public bool goSpinning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Spinning Door")
        {
         goSpinning = true;
            // controller.enabled = false;
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (goSpinning == true)
        {
            // controller.enabled = false;
        }
    }
}
