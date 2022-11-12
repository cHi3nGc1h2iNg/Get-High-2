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
            FindObjectOfType<GameManager>().LevelComplete();
            levelCompleteMenu.gameObject.SetActive(true);
            ButtonPause.gameObject.SetActive(false);
        }
    }
}
