using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableGuns : MonoBehaviour
{
    [SerializeField]private Button pP, pA, pR, pS, cP, cA, cR, cS;
    private UnlockedGuns _unlockedGuns;
    void Awake(){
     _unlockedGuns = GameObject.Find("UnlockedGuns").GetComponent<UnlockedGuns>();   
        if(_unlockedGuns.purplePistol){
            pP.interactable = false;
        }
        if(_unlockedGuns.purpleAR){
            pA.interactable = false;
        }
        if(_unlockedGuns.purpleRocket){
            pR.interactable = false;
        }
        if(_unlockedGuns.purpleSniper){
            pS.interactable = false;
        }
        if(_unlockedGuns.colorPistol){
            cP.interactable = false;
        }
        if(_unlockedGuns.colorAR){
            cA.interactable = false;
        }
        if(_unlockedGuns.colorSniper){
            cS.interactable = false;
        }
        if(_unlockedGuns.colorRocket){
            cR.interactable = false;
        }
    }

    
}
