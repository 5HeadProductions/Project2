using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemShopEnabler : MonoBehaviour
{


    public GameObject gemShop;
    public GameObject mainMenu;
    // Start is called before the first frame update
    public void Awake(){
       /// gemShop = GameObject.Find("GemShopCanvas");
        mainMenu = GameObject.Find("Main Menu");

       // gemShop.SetActive(false);
    }

    public void ActiveGemShop(){
        gemShop.SetActive(true);
    }

    public void ActivateMain(){
        gemShop.SetActive(false);
        mainMenu.SetActive(true);
    }
}
