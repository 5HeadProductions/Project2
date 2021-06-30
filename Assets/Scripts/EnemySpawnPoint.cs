using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    public GameObject enemyClone;
    void Start()
    {

        int rand = Random.Range(1, 5);
        
        for (int i = 0; i < rand; i++)
        {
            Instantiate(Enemy,transform.position,Quaternion.identity);
        }
        
        Destroy(gameObject, 5f);
    }

    
}
