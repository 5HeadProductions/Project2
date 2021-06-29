using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopEnabler : MonoBehaviour
{
    public GameObject shopCanvas;
    

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            shopCanvas.SetActive(true); 
        }
    } 

}
