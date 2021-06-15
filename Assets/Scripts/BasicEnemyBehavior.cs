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
    [SerializeField] private float chaseSpeed, attackRange;
    [SerializeField] private int  health, attackDamage, currHealth;
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

    //attacking and doing damage
    private PlayerManager playerInstance;
    public HUD _hud;
    public bool inAttackRange;
    [SerializeField]private Transform attackPoint;
   private float attackRate = 2f; // the amount of time before being able to attack
   private float timeUntilAttack = 0; // the next time the zombie is able to attack again

   //taking damage and reducing health bar
   public EnemyHealthBar enemyHealthBar;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start(){
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
        currHealth = health; //the zombie starts the level with max health
        enemyHealthBar.SetMaxHealth(health);
    }

    private void Update()
    {
        //check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patrol();
        
        inAttackRange = Physics.CheckSphere(attackPoint.position, attackRange, whatIsPlayer);
        if(inAttackRange) Attack();

    }


    //fixedUpdate is for physics since update might make the logic faulty
    private void FixedUpdate()
    {
        if(playerInSightRange) Chase();
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
    
    private void Attack() // attacking animation needs to be added.
    {
        if(Time.time > timeUntilAttack){
        playerInstance.currentHealth -= attackDamage;  // lowering the players current health
        _hud.SetHealth(playerInstance.currentHealth);  // adjusting the slider to the players new health value
        timeUntilAttack = Time.time + attackRate;      // timeUntilAttack = the next time we are able to attack, 
                                                       // TIME  = 3, attackeRate = 2, we should be able to attack until time reaches 5, 
                                                       // so 5 is stored in timeUntilAttack

        }  
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawSphere(attackPoint.position, attackRange);
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


    public void reduceHealth(int damage){ // enemy taking damage
        this.currHealth -= damage;
        enemyHealthBar.SetHealth(currHealth);
        
    }

}
