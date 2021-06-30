using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  //Singeleton to keep track of what the player needs throughout every scene
    public static PlayerManager playerInstance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject primaryWeapon;      //default whenplayer script awake

    public int currentHealth, maxHealth = 100, coins, gems, primaryAmmo, secondaryAmmo;

    private void Awake() {
        if(playerInstance == null){ // on awake checking for this gameobject
            playerInstance = this; // if the gameobject doesn't exist then using playerInstance
        }
        else{
            Destroy(gameObject); // if the gameobject is already there then we destroy it so we only reference the first time it appeared
            return;
        }
        DontDestroyOnLoad(gameObject); // carrying through every scene

       player = GameObject.FindGameObjectWithTag("Player");

       var weaponClone = Instantiate(primaryWeapon, primaryWeapon.transform.position, primaryWeapon.transform.rotation);

       weaponClone.transform.parent = player.transform;
       
       weaponClone.transform.position = new Vector3(0.239999995f, 1.98479891f, 0.685321569f);

       weaponClone.GetComponentInChildren<FirePoint>().enabled = true;
       //Transform tmp = weaponClone.transform.GetChild(1);  //for rocket firepoints
       //tmp.gameObject.GetComponent<FirePoint>().enabled = true;
    }

    
}
