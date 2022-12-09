using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPunch2_3 : MonoBehaviour
{
    public CharacterController controller;
    public bool triggerPunching = false;
    public bool donePunching = true;
    public float speed = 6.0f;
    public bool isSpinning = false;

    public bool lockView = false;
    public bool lockMouse = false;
    private float timer = 0;

    private float angleNow;
    private float deltaAngle = 0.4f;
    private bool flag = false;

    private Vector3 punchingRoomPosition = new Vector3 (6f, 1.25f, 40f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Punching Door")
        {
            triggerPunching = true;
            donePunching = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Punching Door")
        {
            triggerPunching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (donePunching == false)
        {
            if (flag == false)
            {
                flag = true;
                controller.enabled = false;
                lockMouse = true;
                angleNow = controller.transform.rotation.eulerAngles.y;
            }
            
            angleNow += deltaAngle;
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, punchingRoomPosition, Time.deltaTime * speed);
            // controller.transform.rotation = Quaternion.Euler(0f, angleNow, 0f);

            if ((controller.transform.position - punchingRoomPosition).magnitude <= 0.01f)  //  && Mathf.Abs(angleNow) < 0.01f
            {
                controller.transform.position = punchingRoomPosition;
                if (timer < 3)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    donePunching = true;
                    timer = 0;
                    flag = false;
                }
                
                
                
            }
        }
    }
}
