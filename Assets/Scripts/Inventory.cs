using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Text coin_txt, gem_txt;
    [SerializeField]private int currentCoins, currentGems;

    [SerializeField]private GameObject BottomGun, TopGun; // used to display the current gun equiped.
    [SerializeField]private Texture2D bottomG,topG;
    private Texture2D  holderG;

    public Dictionary<string, GameObject> guns = new Dictionary<string, GameObject>();// store all the guns in the game
    private PlayerManager playerInstance;
    void Start(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        currentCoins = playerInstance.coins;
        currentGems = playerInstance.gems;

        coin_txt.text = currentCoins.ToString();
        gem_txt.text = currentGems.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentCoins != playerInstance.coins){
            currentCoins = playerInstance.coins;
            coin_txt.text = currentCoins.ToString();
        }
        if(currentGems != playerInstance.gems){
            currentGems = playerInstance.gems;
            gem_txt.text = currentGems.ToString();
        }
        
    }


    public void Equipped(){ // bottom gun is the ewuipped gun
    Debug.Log("HIHI");
        holderG = topG; // the player pressed on the top gun to equip it
        bottomG = topG; // currently eqioped gun goes to the top
        bottomG = holderG; // top gun goes to the bottom


    }
}
