using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopAssignment : MonoBehaviour
{
    //upgrade the weapons of the players
    //this script is attached to the ShopCanvas
    [SerializeField]private TextMeshProUGUI currentHealth_Txt, ammo_Txt, coin_Txt, gem_Txt;
    private PlayerManager playerInstance;
   [SerializeField] private GameObject shopCanvas;
    private FirePoint ammo;
    // Start is called before the first frame update
    void Start()
    { 
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        ammo = GameObject.Find("FirePoint").GetComponent<FirePoint>();
        currentHealth_Txt.text = "Health " + playerInstance.currentHealth.ToString();
        coin_Txt.text = playerInstance.coins.ToString();
        gem_Txt.text = playerInstance.gems.ToString();
    }

    void OnEnable(){
        Pause();
    }

    public void Pause(){
        Time.timeScale = 0;

    } 

    public void Resume(){
        Debug.Log("Button pressed");
        Time.timeScale = 1;
        shopCanvas.SetActive(false);
    }
}
