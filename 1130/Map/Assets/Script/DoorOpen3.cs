using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen3 : MonoBehaviour {

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
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(OpenDoor());
            }
        }
    }

        IEnumerator OpenDoor()
    {
        isOpening = true;
        door.GetComponent<Animator>().Play("DoorOpen3");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(18.0f);
        door.GetComponent<Animator>().Play("New State");
        isOpening = false;
    }

}