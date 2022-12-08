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
    public GoToSpinningRoom goToSpinningRoom;
    public Animator animator;

    private float speed = 0f;
    public float targetSpeed = 7.0f;
    public float addSpeed = 2.5f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //add gravity
    public float gravity = -5.0f;

    public bool isSpinning = false;
    private bool pauseCnt = false;

    public bool lockMouse = false;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        #region movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward + gravity * Vector3.up;
            if (speed < targetSpeed)
            {
                speed += addSpeed * Time.deltaTime;
            }
            else if (direction.magnitude <= 0.01f)
            {
                speed = 0;
            }
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);        
            animator.SetFloat("Speed", speed);
        }
        #endregion





        if (goToSpinningRoom.lockMouse)
        {
            freelook.m_XAxis.m_MaxSpeed = 0;
        }
        else
        {
            freelook.m_XAxis.m_MaxSpeed = 150f;
        }


        
    }

}
