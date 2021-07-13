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

            if(SceneManager.GetActiveScene().name == "EasyDungeon" && GameObject.Find("EasyBasicBoss(Clone)") == null){
            SceneManager.LoadScene("EasyDungeon");
            playerInstance.gems += _easyGemDrop;   
            }

            if(SceneManager.GetActiveScene().name == "MediumDungeon" && GameObject.Find("MediumBasicBoss(Clone)") == null && GameObject.Find("MediumRangedBoss(Clone)") == null){
            SceneManager.LoadScene("MediumDungeon");
            playerInstance.gems += _mediumGemDrop;   
            }

            if(SceneManager.GetActiveScene().name == "HardDungeon" && GameObject.Find("HardBasicBoss(Clone)") == null && GameObject.Find("HardRangedBoss(Clone)") == null){
            SceneManager.LoadScene("HardDungeon");
            playerInstance.gems += _hardGemDrop;   
            }
              
            
            

        }

    }
}
