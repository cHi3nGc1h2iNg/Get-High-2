using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public pauseButton pauseButton;
    public void Quit()
    {
        if (SceneManager.GetActiveScene().name == "Stage 1")
        {
            SceneManager.LoadScene("Level1Map");
        }
        else if (SceneManager.GetActiveScene().name == "Stage 3")
        {
            SceneManager.LoadScene("Level2Map");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseButton.Pause();
    }
    public void Resume()
    {
        pauseButton.Pause();
        pauseButton.showButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
