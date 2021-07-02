using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndOfLevel : MonoBehaviour
{
    GameObject boss;
    public int gemDrop;

    private PlayerManager playerInstance;
   
    
    void Start(){
        boss = GameObject.Find("TmpBoss(Clone)");
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        
    }

    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Player") && boss == null){
            playerInstance.gems += gemDrop;     
            
            SceneManager.LoadScene("EasyDungeon");

        }

    }
}
