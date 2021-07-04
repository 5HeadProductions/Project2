using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] Enemies;
 
    void Start()
    {

        int rand = Random.Range(1, 2);
        int enemyRand = Random.Range(0,Enemies.Length - 1);
        
        for (int i = 0; i < rand; i++)
        {
            Instantiate(Enemies[enemyRand],transform.position,Quaternion.identity);
        }
        
        Destroy(gameObject, 5f);
    }

    
}
