using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  //Singeleton to keep track of what the player needs throughout every scene
    public static PlayerManager playerInstance;
    [SerializeField] public GameObject player;
     public GameObject primaryWeapon;      //default whenplayer script awake

     [SerializeField]private WeaponHolder weaponHolder; //used to keep track of what weapon the player has equipped

    public int currentHealth, maxHealth = 100, coins, gems, primaryAmmo, secondaryAmmo, rocketAmmo,primaryIndex = 1, secondaryIndex = 0;
    public int movementMulti = 0; //used to keep track of how many times the player has purchased the movement speed 
    private void Awake() {

        if(playerInstance == null){ // on awake checking for this gameobject
            playerInstance = this; // if the gameobject doesn't exist then using playerInstance
        }
        else{
            Destroy(gameObject); // if the gameobject is already there then we destroy it so we only reference the first time it appeared
            return;
        }
    DontDestroyOnLoad(gameObject); // carrying through every scene
    }


    
}
