using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gangsterAnimation : MonoBehaviour
{
    private Animator gangsterAnimator;
    public Animator junkieAnimator;
    public GameObject ganster;
    public GameObject junkie;
    private float dist;
    //public bool gameIsOver = false;
    public Text textGameOver;
    private AudioSource playerAudio;
    public AudioClip punchSound;
    
    // Start is called before the first frame update
    void Start()
    {
        gangsterAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(ganster.transform.position,junkie.transform.position);
        if (gangsterAnimator != null)
        {
            if (dist <= 3)
            {
                Debug.Log("in range");
                
                
                StartCoroutine(Punch());
                
                
            }
        }
    }
    IEnumerator Punch()
    {
        yield return new WaitForSeconds(0.5f);
        //gangsterAnimator.SetTrigger("trigGameOver");
        gangsterAnimator.Play("punch");
        // playerAudio.PlayOneShot(punchSound, 1.0f);

        yield return new WaitForSeconds(0.3f);
        junkie.gameObject.transform.position = new Vector3(junkie.gameObject.transform.position.x, 2.0f, junkie.gameObject.transform.position.z);
        junkieAnimator.Play("die");
        yield return new WaitForSeconds(1f);
        textGameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        textGameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        
    }
}
