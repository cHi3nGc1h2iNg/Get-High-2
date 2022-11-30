using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string previousScene = "GameMenu";
    public void LoadSceneGameMenu()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameMenu");
        Debug.Log(previousScene);
    }
    public void LoadSceneSelectLevel()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SelectLevel");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel1Map()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level1Map");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel2Map()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level2Map");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel3Map()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level3Map");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel1()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Stage 1");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel2()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Stage 3");
        Debug.Log(previousScene);
    }
    public void LoadSceneLevel3()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level3");
        Debug.Log(previousScene);
    }
    public void LoadSceneReturn()
    {
        
        //SceneManager.LoadScene(previousScene);
        //Debug.Log(previousScene);
        if (SceneManager.GetActiveScene().name == "Stage 1")
        {
            SceneManager.LoadScene("Level1Map");
        }
        if (SceneManager.GetActiveScene().name == "Level1Map" || SceneManager.GetActiveScene().name == "Level2Map")
        {
            SceneManager.LoadScene("SelectLevel");
        }
        if (SceneManager.GetActiveScene().name == "SelectLevel")
        {
            SceneManager.LoadScene("GameMenu");
        }

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
