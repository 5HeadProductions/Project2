using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script is attatched to the shop itself
public class ShopEnabler : MonoBehaviour
{
    public GameObject shopCanvas;
    public void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            shopCanvas.SetActive(true); 
        }
    } 

}
