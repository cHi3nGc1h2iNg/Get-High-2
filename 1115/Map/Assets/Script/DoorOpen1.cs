using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour {

    public float open = 100f;
    public float range = 10f;

    public GameObject door;
    public bool isOpening = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
        }
    }
    public GameObject player;
    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name); //

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(OpenDoor());
            }
        }
    }

//     public class TriggerExample : MonoBehaviour
// {
//     private void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("An object entered.");
//     }
//     private void OnTriggerStay(Collider other)
//     {
//         Debug.Log("An object is still inside of the trigger");
//     }
//     private void OnTriggerExit(Collider other)
//     {
//         Debug.Log("An object left.");
//     }
// }

    // //Here!
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Junkie" && shootPressed)
    //     {
    //         OpenDoor();
    //     }
    // }

        IEnumerator OpenDoor()
    {
        //Debug.Log(door.name);
        isOpening = true;
        door.GetComponent<Animator>().Play("DoorOpen1");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        door.GetComponent<Animator>().Play("New State");
        isOpening = false;
    }

}