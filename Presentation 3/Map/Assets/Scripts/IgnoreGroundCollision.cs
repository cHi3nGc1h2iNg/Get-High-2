using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGroundCollision : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Junkie;
    /*
    void onCollisionEnter(Collision col)
    {
        if (col.tag == "Ignore")
        {
            Physics.IgnoreCollision()
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(Ground.GetComponent<Collider>(), Junkie.GetComponent<Collider>());
    }
}
