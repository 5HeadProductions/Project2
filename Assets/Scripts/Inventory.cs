using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Text coin_txt, gem_txt;
    [SerializeField]private int currentCoins, currentGems;


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
}
