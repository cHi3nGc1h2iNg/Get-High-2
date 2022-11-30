using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkieObstacleHit : MonoBehaviour
{
    [SerializeField]
     private float forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null)
        {
            Vector3 forceDirc = hit.gameObject.transform.position - transform.position;
            forceDirc.y = 0;
            forceDirc.Normalize(); 

            rigidbody.AddForceAtPosition(forceDirc * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
