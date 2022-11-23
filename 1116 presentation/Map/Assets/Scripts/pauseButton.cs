using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pauseButton : MonoBehaviour
{
    public Button ButtonPause;
    //public bool show = true;
    private bool pauseCnt = false;
    public GameObject pauseMenu;

    public void hideButton()
    {
            ButtonPause.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
    }
    public void showButton()
    {
            ButtonPause.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
    }
    public void Pause()
    {
        if (pauseCnt == false)
        {
            Time.timeScale = 0f;
            pauseCnt = true;
        }
        
        else
        {
            Time.timeScale = 1f;
            pauseCnt = false;
        }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
