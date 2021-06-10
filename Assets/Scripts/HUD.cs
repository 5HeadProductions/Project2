using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI coinTXT,healthTXT;

    private PlayerManager playerInstance;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinTXT.text = playerInstance.coins.ToString();
        healthTXT.text = playerInstance.health.ToString();
    }
}
