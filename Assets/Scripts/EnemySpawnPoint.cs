using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    void Start()
    {
        
        Instantiate(Enemy,transform.position,Quaternion.identity);
        Debug.Log("EnemySpawned");
    }

    
}
