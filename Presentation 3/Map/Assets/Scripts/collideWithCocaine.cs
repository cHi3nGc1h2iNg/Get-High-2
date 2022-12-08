using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideWithCocaine : MonoBehaviour
{
    public GameObject coke;
    public GameObject junkie;
    private float dist;
    public GameObject levelCompleteMenu;
    public GameObject ButtonPause;
    public bool isHigh = false;
    public Animator junkieAnimator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(coke.transform.position,junkie.transform.position);
        if (dist <= 2)
        {
            isHigh = true;
            StartCoroutine(Dance());
            FindObjectOfType<GameManager>().LevelComplete();
            levelCompleteMenu.gameObject.SetActive(true);
            ButtonPause.gameObject.SetActive(false);
        }
    }
    IEnumerator Dance()
    {
        yield return new WaitForSeconds(0.5f);
        junkie.gameObject.transform.position = new Vector3(junkie.gameObject.transform.position.x, 2.5f, junkie.gameObject.transform.position.z);
        junkieAnimator.Play("celebrate");
        yield return new WaitForSeconds(4.5f);
        {
            
        }
    }
    
}
