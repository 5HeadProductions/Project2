using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string playSceneName = "EasyDungeon";
    private string playMediumDungeon = "MediumDungeon";
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
    private int purpleCost = 5;
    private int purpleCostSR = 10;
    private int colorCost = 20;
    private int colorCostSR = 25;

    private LevelLoader transition, transitionUI;



        // Start is called before the first frame update
        
    void Start()
    {
        if(SceneManager.GetActiveScene().name == playSceneName || SceneManager.GetActiveScene().name == playHardDungeon ||
            SceneManager.GetActiveScene().name == playMediumDungeon){
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
           transition = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
           transitionUI = GameObject.Find("UILoader").GetComponent<LevelLoader>();
        }
    }
    
    public void LoadMainMenu(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        playerInstance.coins = 0;
        SceneManager.LoadScene(main);
    }

    public void LoadPlay(){
      GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        transition.LoadNextLevel();
        transitionUI.LoadNextLevel();
        StartCoroutine(WaitForTransition());
      //  SceneManager.LoadScene(playableScenes[GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene]);
    }
    IEnumerator WaitForTransition(){
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(playableScenes[GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene]);
    }

    public void Replay(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        playerInstance.primaryWeapon = weaponHolder.Weapons[1];
        playerInstance.coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChooseDifficultyCanvas(){
        
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");

        difficultyCanvas = GameObject.Find("MenuManager");
        
        GameObject.Find("Main Menu").gameObject.SetActive(false);

        difficultyCanvas.GetComponent<DifficultyEnabler>().TurnOn();;
    
    }
    /*

    The below code is used in the Main Menu to load the different dificulties when the player click on the difficulty button

    */
    public void DifficultyBackButton(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");

        difficultyCanvas = GameObject.Find("MenuManager");
        difficultyCanvas.GetComponent<DifficultyEnabler>().TurnOnMain();
    
    }

    public void EasyDifficulty(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 0;
    }

     public void MediumDifficulty(){
         GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 1;
    }

     public void HardDifficulty(){
         GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        GameObject.Find("MenuManager").GetComponent<DifficultyEnabler>().currentDungeonScene = 2;
    }

/*

Permenatly unlocking weapons through the gem shop

*/
   public void GemShopActive(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        gemShop = GameObject.Find("Shop");
        GameObject.Find("Main Menu").gameObject.SetActive(false);
        gemShop.GetComponent<GemShopEnabler>().ActiveGemShop();

   }
   public void GemShopDeactivate(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        gemShop = GameObject.Find("Shop");
        gemShop.GetComponent<GemShopEnabler>().ActivateMain();
   }
    public void EnablePurplePistol(){
          GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
          GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>(); //finding the canvas when it is active
        if(_unlockedGuns.purplePistol != true){
            if(playerInstance.gems >= purpleCost){ // 5
                _unlockedGuns.purplePistol = true;
                playerInstance.gems -= purpleCost;
                PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
                gemCanvas.pP.interactable = false; // setting the button to false if the already own it
            }    
        }else{
            gemCanvas.pP.interactable = false; // setting the button to false if the already own it
        }
    }
    public void EnablePurpleAR(){
          GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.purpleAR != true){
            if(playerInstance.gems >= purpleCost){
             _unlockedGuns.purpleAR = true;
                playerInstance.gems -= purpleCost;
                PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
                gemCanvas.pA.interactable = false;
            }
        }else{
            gemCanvas.pA.interactable = false;
        }
    }
    public void EnablePurpleSniper(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
            if(_unlockedGuns.purpleSniper != true){
                if(playerInstance.gems >= purpleCostSR){
                    _unlockedGuns.purpleSniper = true;
                    playerInstance.gems -= purpleCostSR;
                    PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
                    gemCanvas.pS.interactable = false;
                }        
            }else{
                gemCanvas.pS.interactable = false;
            }
    }
    public void EnablePurpleRocket(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.purpleRocket != true){
        if(playerInstance.gems >= purpleCostSR){
        _unlockedGuns.purpleRocket = true;
            playerInstance.gems -= purpleCostSR;
            PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
            gemCanvas.pR.interactable = false;
            }
        }else
        {
            gemCanvas.pR.interactable = false;
        }
    }

    public void EnableColorPistol(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.colorPistol != true){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorPistol = true;
            playerInstance.gems -= colorCost;
            PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
            gemCanvas.cP.interactable = false;
            }
        }else{
            gemCanvas.cP.interactable = false;
        }
    }
    public void EnableColorAR(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.colorAR != true){
        if(playerInstance.gems >= colorCost){
            _unlockedGuns.colorAR = true;
            playerInstance.gems -= colorCost;
            PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
            gemCanvas.cA.interactable = false;
        }

        }else{
            gemCanvas.cA.interactable = false;
        }
    }
    public void EnableColorSniper(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.colorSniper != true){
        if(playerInstance.gems >= colorCostSR){
            _unlockedGuns.colorSniper = true;
            playerInstance.gems -= colorCostSR;
            PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
            gemCanvas.cS.interactable = false;
        }

        }else{
            gemCanvas.cS.interactable = false;
        }
    }
    public void EnableColorRocket(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
        GemShop gemCanvas = GameObject.Find("GemShopCanvas").GetComponent<GemShop>();
        if(_unlockedGuns.colorRocket != true){
        if(playerInstance.gems >= colorCostSR){
            _unlockedGuns.colorRocket = true;
            playerInstance.gems -= colorCostSR;
            PlayerPrefs.SetInt("LifeTimeGems", playerInstance.gems);
            gemCanvas.cR.interactable = false;
        }

        }else
        {
            gemCanvas.cR.interactable = false;
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

    public void QuitGame(){
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Click");
        Application.Quit();
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
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
            if(shopCanvas.dPistol.interactable == false) shopCanvas.dPistol.interactable = true; //enabling the default pistol to be purchased
            int index = 4; 
             bool isEquipped = inventory.SetPistolUI(index);
            if(isEquipped) Equip(index); //only if the player is holding the gun we want to spawn it in right away else just change the sprite
            else playerInstance.secondaryIndex = index;
            inventory.ReloadSecondary();
            playerInstance.coins -= 400;
            }
            // else the play has it unlocked but can't afford it
        }
        //else the player hasn't unlocked the gun to use in game
    }
    public void ColorPistol(){
        if(shopCanvas.cPistol.interactable){
            if(playerInstance.coins >= 600){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
            if(shopCanvas.dPistol.interactable == false) shopCanvas.dPistol.interactable = true; //enabling the default pistol to be purchased
            int index = 8; 
            bool isEquipped = inventory.SetPistolUI(index);
            if(isEquipped) Equip(index);
            else playerInstance.secondaryIndex = index;
            inventory.ReloadSecondary();
            playerInstance.coins -= 600;
            }
            // else the play has it unlocked but can't afford it
        }
        //else player hasn't unlocked it
    }
    public void DefaultAR(){
        if(shopCanvas.dAr.interactable){
            if(playerInstance.coins >= 300){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
            int index = 1;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index);
            inventory.ReloadPrimary();
            playerInstance.coins -= 300;
            }
        }
    }
    public void PurpleAR(){
        if(shopCanvas.pAr.interactable){
            if(playerInstance.coins >= 700){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 5;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();
                playerInstance.coins -= 700;
            }
        }
    }
    public void ColorAR(){
        if(shopCanvas.cAr.interactable){
            if(playerInstance.coins >= 1300){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 9;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();
                playerInstance.coins -= 1300;
            }
        }
    }
    public void DefaultSniper(){
        if(playerInstance.coins >= 300){
             GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
            if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
            int index = 2;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index); 
            inventory.ReloadPrimary();   
            playerInstance.coins -= 300;
        }
    }
    public void PurpleSniper(){
        if(shopCanvas.pSniper.interactable){
            if(playerInstance.coins >= 600){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 6;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();   
                playerInstance.coins -= 600;
            }
        }
    }
    public void ColorSniper(){
        if(shopCanvas.cSniper.interactable){
            if(playerInstance.coins >= 1300){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 10;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadPrimary();    
                playerInstance.coins -= 1300;
            }
        }
    }
    public void DefaultRocket(){
        if(playerInstance.coins >= 400){
             GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
            if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
            int index = 3;
            bool isEquipped = inventory.SetPrimaryWeaponUI(index);
            if(isEquipped) Equip(index);
            inventory.ReloadRockets();
            playerInstance.coins -= 400;
        }
    }
    public void PurpleRocket(){
        if(shopCanvas.pRocket.interactable){
            if(playerInstance.coins >= 800){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 7;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadRockets();
                playerInstance.coins -= 800;
            }
        }
    }   
    public void ColorRocket(){
        if(shopCanvas.cRocket.interactable){
            if(playerInstance.coins >= 1500){
                 GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Purchased");
                if(shopCanvas.dAr.interactable == false) shopCanvas.dAr.interactable = true; //enabling the default AR to be purchased
                int index = 11;
                bool isEquipped = inventory.SetPrimaryWeaponUI(index);
                if(isEquipped) Equip(index);
                inventory.ReloadRockets();
                playerInstance.coins -= 1500;
            }
        }
    }



}
