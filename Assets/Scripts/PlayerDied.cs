using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins, gems;
    public Animator animator;
    private int endCoin,endGems, growthRate = 1; // endCoin is the value for the coins that is being updated in the canvas
    private bool canvasLoaded, doneCountingCoins, doneCountingGems;
    private PlayerManager playerInstance;
    private WeaponHolder weaponHolder;
    public GameObject gunPlacement;

    public GameObject player;
    Vector3 scaleChange = new Vector3(.5f, .5f, .5f);
    public void Appear(){ // the buttons slowly appear
        animator.SetBool("isActive", true);
        
    }
    public void Start(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); 
        weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
        gunPlacement = GameObject.Find("GunPlacement");
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[playerInstance.primaryIndex], weaponHolder.Weapons[playerInstance.primaryIndex].transform.position, //Instantiate a clone of desired weapon
                weaponHolder.Weapons[playerInstance.primaryIndex].transform.rotation);
        weaponClone.transform.parent = player.transform; //player gets child: weapon    
        weaponClone.transform.position = gunPlacement.transform.position;   //assigning the newly spawned weapon The ARVector (position) 
        weaponClone.transform.rotation = player.transform.rotation; 
        weaponClone.transform.Rotate(new Vector3(0f, 180f, 0f));  //assigning the newly spawned weapon The ARVector (position) 
        weaponClone.transform.localScale += scaleChange;
    }

   public void Update(){

       if(!doneCountingCoins){ // update "works" while done counting is false
       coins.text = "-" + endCoin.ToString("0");
       if(endCoin == playerInstance.coins) doneCountingCoins = true; // when the values match we "stop" the update by setting doneCounting to true

       if(gameObject.activeInHierarchy){ // checking the canvas appeared on the screen, this is set active in the HUD scripts
           canvasLoaded = true;
       }
       if(canvasLoaded){
          StartCoroutine(LoadCoins());
            }
       }
    
       GemCounter();
    }
    public void GemCounter(){
        PlayerPrefs.SetInt("LifeTimeGems", PlayerPrefs.GetInt("LifeTimeGems") + playerInstance.gems); // updating the players gems value by adding their previous gem count plus the ones they gained in this run
        if(!doneCountingGems){ // update "works" while done counting is false
       gems.text = "+"+ endGems.ToString("0");
       if(endGems == playerInstance.gems) doneCountingGems = true; // when the values match we "stop" the update by setting doneCounting to true
       if(gameObject.activeInHierarchy){ // checking the canvas appeared on the screen, this is set active in the HUD scripts
           canvasLoaded = true;
       }
       if(canvasLoaded){
          StartCoroutine(LoadGems());
            }
       }
    }

    IEnumerator LoadGems(){
        yield return new WaitForSeconds(1);
        if(playerInstance.gems > endGems && endGems != playerInstance.gems){ 
            endGems += growthRate;                                             //giving the incrasing "animation" to the gems
        } 
    }
    IEnumerator LoadCoins(){
        yield return new WaitForSeconds(1);

        if(playerInstance.coins > endCoin && endCoin != playerInstance.coins){ //&& endCoin != playerInstance.C in case a frame is skipped we want to keep adding to endCoin 
            endCoin += growthRate;                                             //giving the incrasing "animation" to the coins
        }  
    }
}
