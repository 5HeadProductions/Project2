using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


//added to basic enemy preFab
//1.follow player at a pace that we can alter
//2.health field and attack damage, attack range
//3.animator component and animator field updates
//4.detect collision between player and enemy / bullet and enemy as well
//5.Patrolling until player is within detection range


public class BasicEnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform target; //player ideally
    [SerializeField] private float chaseSpeed, health, attackDamage, attackRange;
    [SerializeField] private Animator animator;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    
    //patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;
    
    //States
    public float sightRange;
    public bool playerInSightRange;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patrol();
    }

    //fixedUpdate is for physics since update might make the logic faulty
    private void FixedUpdate()
    {
        if(playerInSightRange) Chase();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= 10; //come back to replace the 10 with a field from other
        }

        if (other.gameObject.CompareTag("Player"))
        {
            //update player health
        }
        //if other.tag is player then other.health--
    }

    private void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

    
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    
    

    private void Chase()
    {
        Vector3 dis = Vector3.MoveTowards(gameObject.transform.position, target.position, chaseSpeed);
        gameObject.transform.position = dis;
        transform.LookAt(target);


        
        float velocityZ = Vector3.Dot(dis.normalized, transform.forward);
        float velocityX = Vector3.Dot(dis.normalized, transform.right);   
        animator.SetFloat("VelocityZ", velocityZ, 0.1f,Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f,Time.deltaTime);
    }
}
