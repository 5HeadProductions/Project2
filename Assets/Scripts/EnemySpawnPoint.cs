using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    public GameObject enemyClone;
    void Start()
    {
        
        enemyClone = Instantiate(Enemy,transform.position,Quaternion.identity);
    }

    
}
