using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string playSceneName = "EasyDungeon";
    private string playHardDungeon = "HardDungeon";
    private string weaponScene = "Boss Room";
    private string main = "MainMenu";

    private WeaponHolder weaponHolder;

    private Inventory inventory;
    private PlayerMovement playerMovement;

    private PlayerManager playerInstance;

    private GameObject gunPlacement;
        // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == playSceneName || SceneManager.GetActiveScene().name == playHardDungeon){
        weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        gunPlacement = GameObject.Find("GunPlacement");
        }
    }
    
    public void LoadMainMenu(){
        SceneManager.LoadScene(main);
    }

    public void LoadPlay(){
        SceneManager.LoadScene(playSceneName);
    }

    public void Replay(){
        playerInstance.primaryWeapon = weaponHolder.Weapons[1];
        playerInstance.coins = 0;
        SceneManager.LoadScene(playSceneName);
    }

    public void LoadWeapons(){
        SceneManager.LoadScene(weaponScene);
    }

    public void Equip(int num) // this is for the HUDUI canvas
    {
        
        if (GameObject.FindGameObjectWithTag("Primary") != null || "Secondary" != null)        //if there is a different primary equipped then destroy it
        {    
            Destroy(GameObject.FindGameObjectWithTag("Primary"));
            Destroy(GameObject.FindGameObjectWithTag("Secondary"));  
        }
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[num], weaponHolder.Weapons[num].transform.position, //Instantiate a clone of wanted weapon
                weaponHolder.Weapons[num].transform.rotation);
         playerInstance.primaryWeapon = weaponClone;  



         playerInstance.primaryIndex = num;    




        //weaponClone.transform.Rotate(weaponHolder.player.transform.forward);
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon    
        weaponClone.transform.position = gunPlacement.transform.position;   //assigning the newly spawned weapon The ARVector (position) 
        weaponClone.transform.rotation = weaponHolder.player.transform.rotation; 
        weaponClone.transform.Rotate(new Vector3(0f, 180f, 0f));
        //weaponClone.transform.forward = weaponHolder.player.transform.forward; 
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
      //  playerMovement.firePoint = weaponClone.GetComponentInChildren<FirePoint>();
        StartCoroutine(inventory.NewFirePoint());

    }

// this method is called in the shop canvas when the player is click on the bullet button
    public void PurchasedBullets(){
        // when the player clicks on the ammo button it gives ammo to both guns
       playerInstance.primaryAmmo += 10;
       playerInstance.secondaryAmmo += 10;
    }


    public void PurchaseRockets(){
        playerInstance.rocketAmmo += 5;
    }



    public void PurchaseSpeed(){
        if(playerInstance.movementMulti <= 3) playerInstance.movementMulti ++;
    }



/////    
//The following methods are used when the player buys the gun from the in game store
/////
    public void DefaultPistol(){
        int index = 0; //fixed index location of the sprite in the array
        bool isEquipped = inventory.SetPistolUI(index); // checking if the sprite is at the bottom  = equipped
        if(isEquipped) Equip(index); // if it is equipped then we want to spawn it by calling Equip
        inventory.ReloadSecondary(); // giving the player max ammo after the purchase
    }
    public void PurplePistol(){
        int index = 4; 
       bool isEquipped = inventory.SetPistolUI(index);
       if(isEquipped) Equip(index); //only if the player is holding the gun we want to spawn it in right away else just change the sprite
       inventory.ReloadSecondary();
    }
    public void ColorPistol(){
        int index = 8; 
       // inventory.SetPistolUI(index);
        bool isEquipped = inventory.SetPistolUI(index);
        if(isEquipped) Equip(index);
      
        else playerInstance.secondaryIndex = index;
        inventory.ReloadSecondary();
    }
    public void DefaultAR(){
        int index = 1;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadPrimary();
    }
    public void PurpleAR(){
        int index = 5;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadPrimary();
    }
    public void ColorAR(){
        int index = 9;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadPrimary();
    }
    public void DefaultSniper(){
        int index = 2;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index); 
        inventory.ReloadPrimary();   
    }
    public void PurpleSniper(){
        int index = 6;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadPrimary();   
    }
    public void ColorSniper(){
        int index = 10;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadPrimary();    
    }
    public void DefaultRocket(){
        int index = 3;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadRockets();
    }
    public void PurpleRocket(){
        int index = 7;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadRockets();
    }   
    public void ColorRocket(){
        int index = 11;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
        inventory.ReloadRockets();
    }



}
