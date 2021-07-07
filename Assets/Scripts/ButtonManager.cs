using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string playSceneName = "EasyDungeon";
    private string playHardDungeon = "HardDungeon";

    
   private string[] playableScenes = {"EasyDungeon","MediumDungeon","HardDungeon"};

   
    private string weaponScene = "Boss Room";
    private string main = "MainMenu";
    private WeaponHolder weaponHolder;
    private Inventory inventory;
    private PlayerMovement playerMovement;
    private PlayerManager playerInstance;
    private UnlockedGuns _unlockedGuns;
    private GameObject gunPlacement;
    private ShopAssignment shopCanvas;

    private GameObject difficultyCanvas;
    private GameObject gemShop;
    private int purpleCost = 10;
    private int colorCost = 25;


        // Start is called before the first frame update
        
    void Start()
    {
        if(SceneManager.GetActiveScene().name == playSceneName || SceneManager.GetActiveScene().name == playHardDungeon){
        weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        _unlockedGuns = GameObject.Find("UnlockedGuns").GetComponent<UnlockedGuns>();
        gunPlacement = GameObject.Find("GunPlacement");
        shopCanvas = GameObject.Find("ShopHandler").GetComponent<shopHandler>().shop.GetComponent<ShopAssignment>();
        }
        else{
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            _unlockedGuns = GameObject.Find("UnlockedGuns").GetComponent<UnlockedGuns>();
        }
    }
    
    public void LoadMainMenu(){
        playerInstance.coins = 0;
        SceneManager.LoadScene(main);
    }

    public void LoadPlay(){
        
        SceneManager.LoadScene(playableScenes[GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene]);
    }

    public void Replay(){
        playerInstance.primaryWeapon = weaponHolder.Weapons[1];
        playerInstance.coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChooseDifficultyCanvas(){
        // SceneManager.LoadScene(weaponScene);

        difficultyCanvas = GameObject.Find("MenuManager");
        
        GameObject.Find("Main Menu").gameObject.SetActive(false);

        difficultyCanvas.GetComponent<DifficultyEnabler>().TurnOn();;
    
    }
    /*

    The below code is used in the Main Menu to load the different dificulties when the player click on the difficulty button

    */
    public void DifficultyBackButton(){
        difficultyCanvas = GameObject.Find("MenuManager");
        difficultyCanvas.GetComponent<DifficultyEnabler>().TurnOnMain();
    
    }

    public void EasyDifficulty(){
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 0;
    }

     public void MediumDifficulty(){
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 1;
    }

     public void HardDifficulty(){
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 2;
    }

/*

Permenatly unlocking weapons through the gem shop

*/
   public void GemShopActive(){
        gemShop = GameObject.Find("Shop");
        GameObject.Find("Main Menu").gameObject.SetActive(false);
        gemShop.GetComponent<GemShopEnabler>().ActiveGemShop();

   }
   public void GemShopDeactivate(){
        gemShop = GameObject.Find("Shop");
        gemShop.GetComponent<GemShopEnabler>().ActivateMain();
   }
    public void EnablePurplePistol(){
        if(playerInstance.gems >= purpleCost){
            _unlockedGuns.purplePistol = true;
            playerInstance.gems -= purpleCost;
        }
    }
    public void EnablePurpleAR(){
        if(playerInstance.gems >= purpleCost){
            _unlockedGuns.purpleAR = true;
            playerInstance.gems -= purpleCost;
        }
    }
    public void EnablePurpleSniper(){
        if(playerInstance.gems >= purpleCost){
            _unlockedGuns.purpleSniper = true;
            playerInstance.gems -= purpleCost;
        }        
    }
    public void EnablePurpleRocket(){
        if(playerInstance.gems >= purpleCost){
        _unlockedGuns.purpleRocket = true;
            playerInstance.gems -= purpleCost;
        }
    }

    public void EnableColorPistol(){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorPistol = true;
            playerInstance.gems -= colorCost;
        }
    }
    public void EnableColorAR(){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorAR = true;
            playerInstance.gems -= colorCost;
        }
    }
    public void EnableColorSniper(){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorSniper = true;
            playerInstance.gems -= colorCost;
        }
    }
    public void EnableColorRocket(){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorRocket = true;
            playerInstance.gems -= colorCost;
        }
    }

/*
The code below is used to spawn the weapon the player switches to

*/
    public void Equip(int num)
    {     
        if (GameObject.FindGameObjectWithTag("Primary") != null || "Secondary" != null)        //if there is a different primary equipped then destroy it
        {    
            Destroy(GameObject.FindGameObjectWithTag("Primary"));
            Destroy(GameObject.FindGameObjectWithTag("Secondary"));  
        }
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[num], weaponHolder.Weapons[num].transform.position, //Instantiate a clone of desired weapon
                weaponHolder.Weapons[num].transform.rotation);
         playerInstance.primaryWeapon = weaponClone;  
         playerInstance.primaryIndex = num;    // updating the singleton on what weapon the player us currently holding so it can be equipped again if they die
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon    
        weaponClone.transform.position = gunPlacement.transform.position;   //assigning the newly spawned weapon The ARVector (position) 
        weaponClone.transform.rotation = weaponHolder.player.transform.rotation; 
        weaponClone.transform.Rotate(new Vector3(0f, 180f, 0f));
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
        StartCoroutine(inventory.NewFirePoint());
    }

/*

Purchasing ammunition and speed from the in game shop


*/
    public void PurchasedBullets(){
        // when the player clicks on the ammo button it gives ammo to both guns
       if(playerInstance.coins >= 100){
        playerInstance.primaryAmmo += 10;
        playerInstance.secondaryAmmo += 10;
        playerInstance.coins -= 100;
       }
       //else they can't afford it
  
    }
    public void PurchaseRockets(){
        if(playerInstance.coins >= 250){
            playerInstance.rocketAmmo += 5;
            playerInstance.coins -= 250;
        }
        //else they can't afford it
    }
    public void PurchaseSpeed(){
        if(playerInstance.coins >= 350){
        if(playerInstance.movementMulti <= 3) playerInstance.movementMulti ++;
        playerInstance.coins -= 350;
        }
    }
/*

//////////////////////////////////////////////////////////////////////////////////////////    
//The following methods are used when the player buys the gun from the in game store
//////////////////////////////////////////////////////////////////////////////////////////

*/
    public void DefaultPistol(){
        int index = 0; //fixed index location of the sprite in the array
        bool isEquipped = inventory.SetPistolUI(index); // checking if the sprite is at the bottom  = equipped
        if(isEquipped) Equip(index); // if it is equipped then we want to spawn it by calling Equip
        else playerInstance.secondaryIndex = index; // saving their secondary weapon for when the scene is reloaded
        inventory.ReloadSecondary(); // giving the player max ammo after the purchase
    }
    public void PurplePistol(){
        if(_unlockedGuns.purplePistol){
            if(playerInstance.coins >= 550){
            if(shopCanvas.dPistol.interactable == false) shopCanvas.dPistol.interactable = true; //enabling the default pistol to be purchased
            int index = 4; 
             bool isEquipped = inventory.SetPistolUI(index);
            if(isEquipped) Equip(index); //only if the player is holding the gun we want to spawn it in right away else just change the sprite
            else playerInstance.secondaryIndex = index;
            inventory.ReloadSecondary();
            playerInstance.coins -= 550;
            }
            // else the play has it unlocked but can't afford it
        }
        //else the player hasn't unlocked the gun to use in game
    }
    public void ColorPistol(){
        if(shopCanvas.cPistol.interactable){
            if(playerInstance.coins >= 1000){
            if(shopCanvas.dPistol.interactable == false) shopCanvas.dPistol.interactable = true; //enabling the default pistol to be purchased
            int index = 8; 
            bool isEquipped = inventory.SetPistolUI(index);
            if(isEquipped) Equip(index);
            else playerInstance.secondaryIndex = index;
            inventory.ReloadSecondary();
            playerInstance.coins -= 1000;
            }
            // else the play has it unlocked but can't afford it
        }
        //else player hasn't unlocked it
    }
    public void DefaultAR(){
        if(shopCanvas.dAr.interactable){
            if(playerInstance.coins >= 350){
            int index = 1;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index);
            inventory.ReloadPrimary();
            playerInstance.coins -= 350;
            }
        }
    }
    public void PurpleAR(){
        if(shopCanvas.pAr.interactable){
            if(playerInstance.coins >= 450){
                int index = 5;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();
                playerInstance.coins -= 450;
            }
        }
    }
    public void ColorAR(){
        if(shopCanvas.cAr.interactable){
            if(playerInstance.coins >= 1500){
                int index = 9;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();
                playerInstance.coins -= 1500;
            }
        }
    }
    public void DefaultSniper(){
        if(playerInstance.coins >= 500){
            int index = 2;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index); 
            inventory.ReloadPrimary();   
            playerInstance.coins -= 500;
        }
    }
    public void PurpleSniper(){
        if(shopCanvas.pSniper.interactable){
            if(playerInstance.coins >= 690){
                int index = 6;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();   
                playerInstance.coins -= 690;
            }
        }
    }
    public void ColorSniper(){
        if(shopCanvas.cSniper.interactable){
            if(playerInstance.coins >= 2500){
                int index = 10;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();    
                playerInstance.coins -= 2500;
            }
        }
    }
    public void DefaultRocket(){
        if(playerInstance.coins >= 1000){
            int index = 3;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index);
            inventory.ReloadRockets();
            playerInstance.coins -= 1000;
        }
    }
    public void PurpleRocket(){
        if(shopCanvas.pRocket.interactable){
            if(playerInstance.coins >= 2000){
                int index = 7;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadRockets();
                playerInstance.coins -= 2000;
            }
        }
    }   
    public void ColorRocket(){
        if(shopCanvas.cRocket.interactable){
            if(playerInstance.coins >= 4000){
                int index = 11;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadRockets();
                playerInstance.coins -= 4000;
            }
        }
    }



}
