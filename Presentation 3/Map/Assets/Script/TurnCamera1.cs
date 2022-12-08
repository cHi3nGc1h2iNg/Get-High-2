using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnCamera1 : MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public Camera camera;
    public ThirdPersonMovement1 thirdPersonMovement1;
    public CinemachineFreeLook freelook;
    public GoToSpinningRoom1 goToSpinningRoom1;

    private float spinningAngle = 0;
    private float spinAmount = 1.5f;
    private float spinningAnglePre = 0;
    public bool flag = true;

    private float speedMod = 5.0f;      //a speed modifier
    private Vector3 point;              //the coord to the point where the camera looks at
    private float angleEnd = 0f;

    private float angleInitial;
    private float desiredAngle;
    
    public float upperAngle = 720.0f;
    public float lowerAngle = 180.0f;

    public float timer = 0f;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goToSpinningRoom1.isSpinning)
        {
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
                camera.GetComponent<CinemachineBrain>().enabled = false;
                angleInitial = transform.rotation.eulerAngles.y;
                point = player.transform.position;      // get target's coords
                transform.LookAt(point);                // makes the camera look to it
                flag = false;
                desiredAngle = Random.Range(lowerAngle, upperAngle);
                
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
                thirdPersonMovement1.lockMouse = false;
                camera.GetComponent<CinemachineBrain>().enabled = true;
                goToSpinningRoom1.isSpinning = false;
                angleEnd = 0;
                
            }
        }        
    }

}