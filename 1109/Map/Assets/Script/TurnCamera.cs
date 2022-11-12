using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnCamera : MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public Camera camera;
    public ThirdPersonMovement thirdPersonMovement;
    public PressKeyOpenDoor pressKeyOpenDoor;
    public CinemachineFreeLook freelook;

    private float spinningAngle = 0;
    private float spinningAngleInRange;
    private float spinAmount = 1.5f;
    private float spinningAnglePre = 0;
    public bool flag = true;
    private float headingBiasAdjustSpeed = 0.1f;

    private float speedMod = 5.0f; //a speed modifier
    private Vector3 point; //the coord to the point where the camera looks at
    private float angleEnd = 0f;
    public bool startSpinning = false;

    private float angleInitial;
    private float disiredAngle = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (thirdPersonMovement.isSpinning)
        { 
            
            camera.GetComponent<CinemachineBrain>().enabled = false;
            
            if (angleEnd < disiredAngle)
            {
                if (flag)
                {
                    
                    angleInitial = transform.rotation.eulerAngles.y;
                    point = player.transform.position;      // get target's coords
                    transform.LookAt(point);                // makes the camera look to it
                    flag = false;
                }
                controller.transform.rotation = Quaternion.Euler(0f, angleInitial + angleEnd, 0f);              // absolutely
                transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);   // relatively
                angleEnd += 20 * Time.deltaTime * speedMod;
            }
            else
            {
                thirdPersonMovement.isSpinning = false;
                
                // pressKeyOpenDoor.lockCinemachine = false;
                freelook.m_Heading.m_Bias = angleEnd;
                angleEnd = 0;
                camera.GetComponent<CinemachineBrain>().enabled = true;
                flag = true;
                controller.enabled = true;
            }
        }

        else
        {
            if (freelook.m_Heading.m_Bias != 0)
            {
                if (freelook.m_Heading.m_Bias > 180)
                {
                    freelook.m_Heading.m_Bias -= 360;
                }
                else if (freelook.m_Heading.m_Bias < -180)
                {
                    freelook.m_Heading.m_Bias += 360;
                }
                else
                {
                    if (Mathf.Abs(freelook.m_Heading.m_Bias) < headingBiasAdjustSpeed)
                    {
                        freelook.m_Heading.m_Bias = 0;
                    }
                    else if (freelook.m_Heading.m_Bias > 0)
                    {
                        freelook.m_Heading.m_Bias -= headingBiasAdjustSpeed;
                    }
                    else if (freelook.m_Heading.m_Bias < 0)
                    {
                        freelook.m_Heading.m_Bias += headingBiasAdjustSpeed;
                    }
                }






            // Debug.Log("hihihihihi");

            // if (flag)
            // {
            //     // spinningAngle = transform.rotation.eulerAngles.y;
            //     // spinningAnglePre = spinningAngle;
            //     flag = false;
            //     // Debug.Log("fuck");
            // }


//--------------------------------------------------------------------------------------------------------------------------


        //     spinningAngleInRange = spinningAngle;
            
        //     if (spinningAngleInRange >= 180)
        //     {
        //         spinningAngleInRange = spinningAngleInRange % 360 - 180;
        //     }
    
        //     freelook.m_Heading.m_Bias = spinningAngleInRange;
        //     transform.rotation = Quaternion.Euler(0f, spinningAngleInRange, 0f);
        //     spinningAngle += rotating_speed;

        //     // Debug.Log(spinningAngle);
        //     Debug.Log(spinningAngle - spinningAnglePre);
            
        //     if (spinningAngle - spinningAnglePre >= 360 * spinAmount)
        //     {
                
        //         controller.enabled = true;
        //         freelook.m_Heading.m_Bias = spinningAngle % 360 - 180;
        //         thirdPersonMovement.isSpinning = false;
        //         flag = true;
        //     }
//-------------------------------------------------------------------------------------------------------------------------- 

                
                
            }
        }
        
    }

}