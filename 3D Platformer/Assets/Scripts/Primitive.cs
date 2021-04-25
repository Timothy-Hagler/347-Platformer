using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Primitive : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    // Patrolling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    // Attacking (may use these on range enemies)
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        
            if (!walkPointSet)
                SearchWalkPoint();

            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        
    }

    private void SearchWalkPoint()
    {
        
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
                walkPointSet = true;
        
    }

    private void ChasePlayer()
    {
       
            agent.SetDestination(player.position);
        
    }

    private void Attack()
    {
        
            agent.SetDestination(transform.position);

            //transform.LookAt(player);

            if (!alreadyAttacked)
            {
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
            // Check if player is in sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

          //  if (!playerInSightRange && !playerInAttackRange)
            //    Patrolling();
            if (playerInSightRange && !playerInAttackRange)
                ChasePlayer();
            if (playerInSightRange && playerInAttackRange)
                Attack();
        
        

       
    }
}
