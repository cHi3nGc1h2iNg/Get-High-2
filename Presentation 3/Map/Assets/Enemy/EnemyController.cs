using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public CharacterController controller;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator animator;
    public float patrolingSpeed;
    public float chasingSpeed;
    
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet = false;
    public float walkPointRange;

    //States
    public float sightRange;
    private bool playerInSightRange;

    private void Awake() 
    {
        player = GameObject.Find("Junkie");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patroling()
    {
        Debug.Log("patrol");
        agent.speed = patrolingSpeed;
        if(!walkPointSet) 
            SearchWalkPoint();
            

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 3.0f)
            walkPointSet = false;
    }

    private void ChasePlayer()
    {
        Debug.Log("CHASE");
        agent.speed = chasingSpeed;
        agent.SetDestination(player.transform.position);
        Vector3 distanceToPlayer = transform.position - player.transform.position;
        //
        // if(distanceToPlayer.magnitude < 5.0f)
        //     controller.enabled = false;            
    }

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void Update()
    {
        //check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        Debug.Log(playerInSightRange);
        if (!playerInSightRange) Patroling();
        
        if(playerInSightRange) ChasePlayer();
        
        animator.SetFloat("Move", agent.velocity.magnitude);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
