using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string playSceneName = "RoomGeneration";
    private string weaponScene = "WeaponShop";
    private string main = "MainMenu";

    private WeaponHolder weaponHolder;

    private Inventory inventory;


    private PlayerMovement playerMovement;
        // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == playSceneName){
        weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }
    }
    
    public void LoadMainMenu(){
        SceneManager.LoadScene(main);
    }

    public void LoadPlay(){
        SceneManager.LoadScene(playSceneName);
    }

    public void LoadWeapons(){
        SceneManager.LoadScene(weaponScene);
    }
    
    // called when the player clicks on the top gun button in game on the HUD
    public void HUDEquip(){
        var equippedGunSprite = inventory.ChangeWeapon();
        for(int i = 0; i < weaponHolder.weaponSprites.Length; i++){
            if(weaponHolder.weaponSprites[i] == equippedGunSprite){
                Equip(i);
                break;
            }
        }

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
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon    
        weaponClone.transform.position = weaponHolder.ARVector + weaponHolder.player.transform.position;   //assigning the newly spawned weapon The ARVector (position)  
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
        playerMovement.firePoint = weaponClone.GetComponentInChildren<FirePoint>();
    }
    

    public void DefaultPistol(){
        int index = 0; // the fixed index location of the sprite in the array
        inventory.SetPistolUI(index);
    }
    public void PurplePistol(){
        int index = 4; 
       bool isEquipped = inventory.SetPistolUI(index);
       if(isEquipped) Equip(index); //only if the player is holding the gun we want to spawn it in right away else just change the sprite
    }
    public void ColorPistol(){
        int index = 8; 
        inventory.SetPistolUI(index);
        bool isEquipped = inventory.SetPistolUI(index);
        if(isEquipped) Equip(index);
    }


    public void DefaultAR(){
        int index = 1;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);

    }
    public void PurpleAR(){
        int index = 5;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);

    }
    public void ColorAR(){
        int index = 9;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);

    }

    public void DefaultSniper(){
        int index = 2;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);    
    }
    public void PurpleSniper(){
        int index = 6;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);    
    }
    public void ColorSniper(){
        int index = 10;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);    
    }
    public void DefaultRocket(){
        int index = 3;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
    }
    public void PurpleRocket(){
        int index = 7;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
    }   
    public void ColorRocket(){
        int index = 11;
        bool isEquipped = inventory.SetPrimaryWeaponUI(index);
        if(isEquipped) Equip(index);
    }



}
