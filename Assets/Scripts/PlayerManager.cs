using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
  //Singeleton to keep track of what the player needs throughout every scene
    public static PlayerManager playerInstance;

    public int currentHealth;
    public int maxHealth = 100;
    public int coins;

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
