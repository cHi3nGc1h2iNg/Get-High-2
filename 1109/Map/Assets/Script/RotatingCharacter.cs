using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCharacter : MonoBehaviour
{
    public CharacterController controller;
    public TurnCamera turnCamera;
    
    private float speedMod = 10.0f; //a speed modifier
    private Vector3 point; //the coord to the point where the camera looks at
    private float angleEnd = 0f;
    private bool flag = true;
    private float angle_initial;


    //private float angle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (turnCamera.startSpinning == true && angleEnd < 360)
        // {
        //     if (flag)
        //     {
        //         angle_initial = transform.rotation.eulerAngles.y;
        //         flag = false;
        //     }
            
        //     transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + angleEnd, 0f);
            
        //     angleEnd += 20 * Time.deltaTime * speedMod;
        //     Debug.Log("hihihihihi");
        //     //Vector3.forward * rotationAngle
        // }
        
    }
}