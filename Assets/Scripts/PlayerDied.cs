using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;

    public Animator animator;
    private int endCoin = 0;
    public int growthRate = 1;
    public bool canvasLoaded;


    private PlayerManager playerInstance;
    public void Appear(){
        animator.SetBool("isActive", true);
        
    }
    public void Start(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        
    }

   public void Update(){
       coins.text = endCoin.ToString();

       if(gameObject.activeInHierarchy){
           canvasLoaded = true;
       }
       if(canvasLoaded){
           LoadCoins();
       }

    }


    public void LoadCoins(){
        if(endCoin != playerInstance.coins && playerInstance.coins > endCoin){
            endCoin += growthRate;
        }

    }
}
