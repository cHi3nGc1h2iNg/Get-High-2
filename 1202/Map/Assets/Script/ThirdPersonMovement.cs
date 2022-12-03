using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public CinemachineFreeLook freelook;
    public Transform cam;
    public GoToSpinningRoom2 goToSpinningRoom2;
    public Rigidbody rb;

    private bool lc = false;
    public float speed = 7.0f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    

    public bool isSpinning = false;
    private bool pauseCnt = false;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (goToSpinningRoom2.lockMouse)
        {
            freelook.m_XAxis.m_MaxSpeed = 0;
        }
        else
        {
            freelook.m_XAxis.m_MaxSpeed = 150f;
        }
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        /*
        if (rb.position.x <= 32 && rb.position.x >=28 && rb.position.z <= 52 && rb.position.z >= 48 && lc == false)
        {
            FindObjectOfType<GameManager>().LevelComplete();
            lc = true;
        }
        */
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        
    }

}
