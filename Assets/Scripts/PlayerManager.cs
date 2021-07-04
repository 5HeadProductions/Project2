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

     [SerializeField]private WeaponHolder weaponHolder;

    public int currentHealth, maxHealth = 100, coins, gems, primaryAmmo, secondaryAmmo, rocketAmmo,primaryIndex = 1, secondaryIndex = 0;
    public int movementMulti = 0;
    private void Awake() {

        if(playerInstance == null){ // on awake checking for this gameobject
            playerInstance = this; // if the gameobject doesn't exist then using playerInstance
     //       weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
     //       primaryWeapon = weaponHolder.Weapons[1];
        }
        else{
            Destroy(gameObject); // if the gameobject is already there then we destroy it so we only reference the first time it appeared
            return;
        }
   //     player = GameObject.FindGameObjectWithTag("Player");

   //    var weaponClone = Instantiate(primaryWeapon, primaryWeapon.transform.position, primaryWeapon.transform.rotation);

   //    weaponClone.transform.parent = player.transform;
       
  //     weaponClone.transform.position = new Vector3(0.239999995f, 1.98479891f, 0.685321569f);

   //    weaponClone.GetComponentInChildren<FirePoint>().enabled = true;
//
    DontDestroyOnLoad(gameObject); // carrying through every scene
       //Transform tmp = weaponClone.transform.GetChild(1);  //for rocket firepoints
       //tmp.gameObject.GetComponent<FirePoint>().enabled = true;
    }


    
}
