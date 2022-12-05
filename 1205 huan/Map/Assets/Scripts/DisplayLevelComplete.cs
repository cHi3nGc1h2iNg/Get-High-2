using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevelComplete : MonoBehaviour
{
    public Text LevelCompleteText;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.levelCompleted == true)
        {
            LevelCompleteText.text = "Level Complete";
        }
        else
        {
            LevelCompleteText.text = "";
        }
    }
}
