using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ShopAssignment : MonoBehaviour
{
    //upgrade the weapons of the players
    //this script is attached to the ShopCanvas
    [SerializeField]private TextMeshProUGUI ammo_Txt, coin_Txt, gem_Txt;
    private PlayerManager playerInstance;
   [SerializeField] private GameObject shopCanvas;
    private FirePoint ammo;


    

    // Start is called before the first frame update
    void Start()
    { 

        ammo = GameObject.Find("FirePoint").GetComponent<FirePoint>();
       
        coin_Txt.text = playerInstance.coins.ToString();
        gem_Txt.text = playerInstance.gems.ToString();
    }

    void OnEnable(){
        Pause();
    if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
       
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
