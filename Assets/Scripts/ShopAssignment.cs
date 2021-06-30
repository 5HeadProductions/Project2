using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ShopAssignment : MonoBehaviour
{
    //upgrade the weapons of the players
    //this script is attached to the ShopCanvas
    [Header("Text Boxes")]
    [SerializeField]private TextMeshProUGUI primaryAmmo_Txt, secondaryAmmo_Txt,rocket_Txt, coin_Txt, gem_Txt;
    private PlayerManager playerInstance;
   [SerializeField] private GameObject shopCanvas;
    private FirePoint firePoint;


    

    // Start is called before the first frame update
    void Start()
    { 
     //   primaryAmmo_Txt.text = playerInstance.primaryAmmo.ToString();
     //   secondaryAmmo_Txt.text = playerInstance.secondaryAmmo.ToString();
        rocket_Txt.text = firePoint.rocketAmmo.ToString();
       
        coin_Txt.text = playerInstance.coins.ToString();
        gem_Txt.text = playerInstance.gems.ToString();
    }

    void OnEnable(){
        Pause();
    firePoint = GameObject.Find("FirePoint").GetComponent<FirePoint>(); //FirePoint has a reference to the ammo
    if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
        primaryAmmo_Txt.text = playerInstance.primaryAmmo.ToString();
        secondaryAmmo_Txt.text = playerInstance.secondaryAmmo.ToString();
       
    }
    void Update(){
         primaryAmmo_Txt.text = playerInstance.primaryAmmo.ToString();
        secondaryAmmo_Txt.text = playerInstance.secondaryAmmo.ToString();
    }

    public void Pause(){
        Time.timeScale = 0;

    } 

    public void Resume(){
        Time.timeScale = 1;
        shopCanvas.SetActive(false);
    }



}
