using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    public Animator animator;
    private int endCoin, growthRate = 1; // endCoin is the value for the coins that is being updated in the canvas
    private bool canvasLoaded, doneCounting;
    private PlayerManager playerInstance;
    public void Appear(){
        animator.SetBool("isActive", true);
        
    }
    public void Start(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); 
    }

   public void Update(){

       if(!doneCounting){ // update "works" while done counting is false
       coins.text = endCoin.ToString("0");
       if(endCoin == playerInstance.coins) doneCounting = true; // when the values match we "stop" the update by setting doneCounting to true

       if(gameObject.activeInHierarchy){ // checking the canvas appeared on the screen, this is set active in the HUD scripts
           canvasLoaded = true;
       }
       if(canvasLoaded){
          StartCoroutine(LoadCoins());
            }
       }
    }
    IEnumerator LoadCoins(){
        yield return new WaitForSeconds(1);

        if(playerInstance.coins > endCoin && endCoin != playerInstance.coins){ //&& endCoin != playerInstance.C in case a frame is skipped we want to keep adding to endCoin 
            endCoin += growthRate;                                             //giving the incrasing "animation" to the coins
        }  
    }
}
