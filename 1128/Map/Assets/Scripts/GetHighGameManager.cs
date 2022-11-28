using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetHighGameManager : MonoBehaviour
{
    

    public bool levelCompleted = false;

    public void LevelComplete()
    {
        if (levelCompleted == false)
        {
            levelCompleted = true;            
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
