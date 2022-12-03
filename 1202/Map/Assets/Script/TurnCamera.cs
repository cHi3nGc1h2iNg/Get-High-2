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
    public CinemachineFreeLook freelook;
    public GoToSpinningRoom2 goToSpinningRoom2;

    private float spinningAngle = 0;
    private float spinningAngleInRange;
    private float spinAmount = 1.5f;
    private float spinningAnglePre = 0;
    public bool flag = true;
    private float headingBiasAdjustSpeed = 0.3f;

    private float speedMod = 5.0f; //a speed modifier
    private Vector3 point; //the coord to the point where the camera looks at
    private float angleEnd = 0f;

    private float angleInitial;
    private float desiredAngle = 180;

    public float timer = 0f;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   



            //controller.GetComponent<ThirdPersonMovement>().enabled = false;
            // controller.GetComponent<CharacterController>().enabled = false;

        




        if (goToSpinningRoom2.isSpinning)
        {
            

            camera.GetComponent<CinemachineBrain>().enabled = false;
            if (flag == true)
            {
                if (timer < 0.5f)
                {
                    timer += Time.deltaTime;
                    return;
                }
                else
                {
                    timer = 0;
                }
                
                
                angleInitial = transform.rotation.eulerAngles.y;
                point = player.transform.position;      // get target's coords
                transform.LookAt(point);                // makes the camera look to it
                flag = false;
                desiredAngle = Random.Range(180, 720);
                
            }

            if (angleEnd < desiredAngle)
            {
                controller.transform.rotation = Quaternion.Euler(0f, angleInitial + angleEnd, 0f);              // absolutely
                transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);   // relatively
                angleEnd += 20 * Time.deltaTime * speedMod;
            }
            else
            {
                freelook.m_Heading.m_Bias += desiredAngle;
                flag = true;
                while (freelook.m_Heading.m_Bias > 180)
                {
                    freelook.m_Heading.m_Bias -= 360;
                }
                while (freelook.m_Heading.m_Bias < -180)
                {
                    freelook.m_Heading.m_Bias += 360;
                }

                controller.enabled = true;
                goToSpinningRoom2.lockMouse = false;
                camera.GetComponent<CinemachineBrain>().enabled = true;
                goToSpinningRoom2.isSpinning = false;
                angleEnd = 0;
                
                
            }
        }        
    }

}