using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

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

    //fixedUpdate is for physics since update might make the logic faulty
    private void FixedUpdate()
    {
        Chase();
    }

    
    private void Chase()
    {
        Vector3 dis = Vector3.MoveTowards(gameObject.transform.position, target.position, chaseSpeed);

        gameObject.transform.position = dis;
    }
}
