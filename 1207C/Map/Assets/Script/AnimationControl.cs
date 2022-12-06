using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    public collideWithCocaine cocaineScript;
    // void Start()
    // {
    //     animator.SetBool("inGame", true);
    // }
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("isBackward", false);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetBool("isBackward", false);
        }
        // if (cocaineScript.isHigh == true)
        // {
        //     Debug.Log("is high");
        //     animator.SetBool("inGame", false);
        //     StartCoroutine(Celebrate());
        // } 
        
        
    }
    IEnumerator Celebrate()
    {
        yield return new WaitForSeconds(0.5f);
        animator.Play("punch");
    }
    /*
    IEnumerator DrunkWalk()
    {
        yield return new WaitForSeconds(0.01f);
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("isBackward", false);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetBool("isBackward", false);
        }
        
    }
    */
}
