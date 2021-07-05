using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] Enemies;
 
    void Start()
    {

        int rand = Random.Range(1, 4);      //random for amount of zombies spawned
        int enemyRand = Random.Range(0,2);  //random # for the type of enemy in array Enemies
        
        for (int i = 0; i < rand; i++)
        {
            Debug.Log(enemyRand);
            Instantiate(Enemies[enemyRand],transform.position,Quaternion.identity);
        }
        
        Destroy(gameObject, 5f);
    }

    
}
