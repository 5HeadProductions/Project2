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

    [Header("GameObjects")]
    [SerializeField]private GameObject speedCost;
    [SerializeField] private GameObject shopCanvas;
    [Header("Buttons")]
    public Button speedButton, pPistol, pAr, pSniper, pRocket, cPistol, cAr, cSniper, cRocket, dPistol, dAr;
    private PlayerManager playerInstance;
    private UnlockedGuns _unlockedGuns;


    void OnEnable(){
        Pause();
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        _unlockedGuns = GameObject.Find("UnlockedGuns").GetComponent<UnlockedGuns>();
        gem_Txt.text = playerInstance.gems.ToString();
        

    }

    void Start(){
      if(pPistol != null)if(_unlockedGuns.purplePistol) pPistol.interactable = true;
      if(pAr != null)if(_unlockedGuns.purpleAR) pAr.interactable = true;
      if(pSniper != null)if(_unlockedGuns.purpleSniper) pSniper.interactable = true;
      if(pRocket != null)if(_unlockedGuns.purpleRocket) pRocket.interactable = true;
      if(cPistol != null)if(_unlockedGuns.colorPistol) cPistol.interactable = true;
      if(cAr != null)if(_unlockedGuns.colorAR) cAr.interactable = true;
      if(cSniper != null)if(_unlockedGuns.colorSniper) cSniper.interactable = true;
      if(cRocket != null)if(_unlockedGuns.colorRocket) cRocket.interactable = true;
      if(dAr != null)if(playerInstance.primaryIndex != 1) dAr.interactable = true;   
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
