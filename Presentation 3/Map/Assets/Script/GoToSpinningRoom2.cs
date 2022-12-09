using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSpinningRoom2 : MonoBehaviour
{
    public CharacterController controller;
    public ThirdPersonMovement thirdPersonMovement;
    public bool triggerMoving = false;
    public bool doneMoving = true;
    public float speed = 6.0f;
    public bool isSpinning = false;

    public bool lockView = false;
    public bool lockMouse = false;
    

    private Vector3 spinningRoomPosition = new Vector3 (-18f, 1.25f, 18f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Spinning Door")
        {
            triggerMoving = true;
            doneMoving = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Spinning Door")
        {
            triggerMoving = false;
        }
    }




    // Update is called once per frame
    void Update()
    {   
        if (doneMoving == false)
        {
            controller.enabled = false;
            lockMouse = true;
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, spinningRoomPosition, Time.deltaTime * speed);

            if ((controller.transform.position - spinningRoomPosition).magnitude <= 0.01f)
            {
                controller.transform.position = spinningRoomPosition;
                doneMoving = true;
                isSpinning = true;
                
            }
        }
    }
}
