using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopAssignment : MonoBehaviour
{
    //this script is attached to the ShopCanvas
    [Header("Text Boxes")]
    [SerializeField]private TextMeshProUGUI primaryAmmo_Txt, secondaryAmmo_Txt,rocket_Txt, coin_Txt, gem_Txt,
    speed_Txt;

    [SerializeField]private GameObject speedCost;
    [SerializeField]private Button speedButton;
    private PlayerManager playerInstance;
   [SerializeField] private GameObject shopCanvas;


    void OnEnable(){
        Pause();
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
       gem_Txt.text = playerInstance.gems.ToString();
    }
    void Update(){
       UpdateCanvas();
    }

//updates the text fields when the player buys a gun, buys ammo, and spends coins
    public void UpdateCanvas(){
        primaryAmmo_Txt.text = playerInstance.primaryAmmo.ToString();
        secondaryAmmo_Txt.text = playerInstance.secondaryAmmo.ToString();
        rocket_Txt.text = playerInstance.rocketAmmo.ToString();
        coin_Txt.text = playerInstance.coins.ToString();
        if(playerInstance.movementMulti >= 3){
            speed_Txt.text = "max";
            speedCost.SetActive(false);
            speedButton.interactable = false;
            
        }
    }


//pausing the game in the background
    public void Pause(){
        Time.timeScale = 0;
    } 
//resuming when the player hits the back button, this was not places in button manager bc button manager would need to get this component only to resume the game
    public void Resume(){
        Time.timeScale = 1;
        shopCanvas.SetActive(false);
    }



}
