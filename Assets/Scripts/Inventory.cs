using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Text coin_txt, gem_txt;
    [SerializeField]private int currentCoins, currentGems;

    [SerializeField]private GameObject bottomGunObject, topGunObject; // used to display the current gun equiped.

    [SerializeField]private RawImage bottomGunImage, topGunImage;
    private Texture  holderG;

    //private GameObject[] gunInLevel = new GameObject[2];

 //   public Dictionary<string, GameObject> guns = new Dictionary<string, GameObject>();// store all the guns in the game
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


    public void Equipped(){ // bottom gun is the equipped gun
      holderG = topGunImage.texture; // the player pressed on the top gun to equip it
      topGunImage.texture = bottomGunImage.texture; // currently equiped gun goes to the top
      bottomGunImage.texture = holderG; // top gun goes to the bottom
  


    }
}
