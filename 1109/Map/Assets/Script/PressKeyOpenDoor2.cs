using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressKeyOpenDoor2 : MonoBehaviour {

    //public GameObject Instruction;
    public GameObject[] AnimeObject;
    public CharacterController controller;
    public ThirdPersonMovement thirdPersonMovement;
    // private TurnCamera turnCamera;

    public bool Action = false;
    public bool oddTimeOpenDoor = false;
    public bool lockCinemachine = false;
    public int doorNumber;
    
    void Start()
    {

    }
    
    void OnTriggerEnter(Collider collision)
    {
        Action = true;

        switch (collision.transform.tag)
        {
            case "Spinning Tag 1":
                doorNumber = 0;
                break;
            case "Spinning Tag 2":
                doorNumber = 1;
                break;
            case "Spinning Tag 3":
                doorNumber = 2;
                break;

            case "Tag 4":
                doorNumber = 3;
                break;
            case "Tag 5":
                doorNumber = 4;
                break;
            case "Tag 6":
                doorNumber = 5;
                break;
            case "Tag 7":
                doorNumber = 6;
                break;
            case "Tag 8":
                doorNumber = 7;
                break;
            case "Tag 9":
                doorNumber = 8;
                break;
            case "Tag 10":
                doorNumber = 9;
                break;
            case "Tag 11":
                doorNumber = 10;
                break;
            case "Tag 12":
                doorNumber = 11;
                break;
            case "Tag 13":
                doorNumber = 12;
                break;
            case "Tag 14":
                doorNumber = 13;
                break;
            case "Spinning Tag 15":
                doorNumber = 14;
                break;
            default:
                break;
        }


        // if (collision.transform.tag == "Spinning Tag 1") Action = true;
    }

    void OnTriggerExit(Collider collision)
    {
        Action = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown("space") && Action == true)
        {
            Action = false;
            
            if (doorNumber < 3 || doorNumber == 14)
            {
                if (oddTimeOpenDoor == false)  // && AnimeObject[0].tag == "Spinning Tag"
                {
                    controller.enabled = false;

                    // GetComponent<Camera>().GetComponent<CinemachineBrain>().enabled = false;
                }
                oddTimeOpenDoor = !oddTimeOpenDoor;
            }

              
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        // Debug.Log(door.name)
        AnimeObject[doorNumber].GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(2.0f);
        yield return new WaitForSeconds(1.0f);
        AnimeObject[doorNumber].GetComponent<Animator>().Play("New State");
    }
}
    