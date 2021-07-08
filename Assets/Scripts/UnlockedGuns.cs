using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedGuns : MonoBehaviour
{
    [Header("Active Guns")]
    public bool purplePistol, purpleAR, purpleSniper, purpleRocket,
                colorPistol, colorAR, colorSniper, colorRocket; 
    private static UnlockedGuns _unlockedGuns;
    private void Awake(){
        if(_unlockedGuns == null){
            _unlockedGuns = this;
        }else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
