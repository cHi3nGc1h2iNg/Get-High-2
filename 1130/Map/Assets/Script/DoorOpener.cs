using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    #region Attributes

    public Transform door;

    public float openSpeed = 5;

    private bool open = false;
    private bool shootPressed = Input.GetKeyDown("f");

    #endregion

    #region MonoBehaviour API

    private void Update()
    {
        if (open)
        {
            //animation
            door.GetComponent<Animator>().Play("DoorOpen1");

        } else
        {
            // animation
            door.GetComponent<Animator>().Play("New State");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Junkie" && shootPressed)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Junkie")
        {
            CloseDoor();
        }
    }

    #endregion

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }
}
