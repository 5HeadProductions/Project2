using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] easyEnemies;
    public GameObject[] mediumEnemies;
    public GameObject[] hardEnemies;
 
    void Start()
    {

        int rand = Random.Range(1, 4);      //random for amount of zombies spawned
        int enemyRand = Random.Range(0,2);  //random # for the type of enemy in array Enemies
        
        for (int i = 0; i < rand; i++)
        {
            if(SceneManager.GetActiveScene().name == "EasyDungeon")
            Instantiate(easyEnemies[enemyRand],transform.position,Quaternion.identity);

            if(SceneManager.GetActiveScene().name == "MediumDungeon")
            Instantiate(mediumEnemies[enemyRand],transform.position,Quaternion.identity);

            if(SceneManager.GetActiveScene().name == "HardDungeon")
            Instantiate(hardEnemies[enemyRand],transform.position,Quaternion.identity);

        }
        
        Destroy(gameObject, 5f);
    }

    
}
