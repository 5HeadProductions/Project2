using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndOfLevel : MonoBehaviour
{
    GameObject boss;
    [SerializeField] private int _easyGemDrop,_mediumGemDrop,_hardGemDrop;

    private PlayerManager playerInstance;
   
    
    void Start(){
        boss = GameObject.Find("TmpBoss(Clone)");
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        
    }

    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Player") && boss == null){

            if(SceneManager.GetActiveScene().name == "EasyDungeon"){
            SceneManager.LoadScene("EasyDungeon");
            playerInstance.gems += _easyGemDrop;   
            }

            if(SceneManager.GetActiveScene().name == "MediumDungeon"){
            SceneManager.LoadScene("MediumDungeon");
            playerInstance.gems += _mediumGemDrop;   
            }

            if(SceneManager.GetActiveScene().name == "HardDungeon"){
            SceneManager.LoadScene("HardDungeon");
            playerInstance.gems += _hardGemDrop;   
            }
              
            
            

        }

    }
}
