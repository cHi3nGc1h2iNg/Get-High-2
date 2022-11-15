using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveToSpinningRoom : MonoBehaviour
{
    public CharacterController controller;
    public CinemachineFreeLook freelook;
    public ThirdPersonMovement thirdPersonMovement;
    public TurnCamera turnCamera;
    public PressKeyOpenDoor pressKeyOpenDoor;

    private Vector3 spinningRoomPosition = new Vector3 (30f, 0f, 10f);

    public float speed = 6.0f;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.enabled == false && pressKeyOpenDoor.lockCinemachine == true)     //  && turnCamera.flag == true
        {
            // delay
            controller.GetComponent<BoxCollider>().enabled = false;
            freelook.m_XAxis.m_MaxSpeed = 0f;
            transform.position = Vector3.MoveTowards(transform.position, spinningRoomPosition, Time.deltaTime * speed);

            if ((transform.position - spinningRoomPosition).magnitude <= 0.01f)
            {
                controller.GetComponent<BoxCollider>().enabled = true;
                thirdPersonMovement.isSpinning = true;
                pressKeyOpenDoor.lockCinemachine = false;
            }
        }
    }
}
