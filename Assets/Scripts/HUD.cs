using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private PlayerManager playerInstance;
    public Slider slider; //slides the health bar up and down
    public Gradient gradient; // changes the color of the slider
    public Image fill;
    [SerializeField]private TextMeshProUGUI txtVal;
    public GameObject playerDied;




    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
        SetMaxHealth();
        
    }

    public void SetMaxHealth(){ // health is replenished after each level, except in hard difficulty
        txtVal.text = playerInstance.maxHealth.ToString() + "/" + playerInstance.maxHealth.ToString();
        slider.maxValue = playerInstance.maxHealth;
        playerInstance.currentHealth = playerInstance.maxHealth;
        slider.value = playerInstance.maxHealth;
        fill.color = gradient.Evaluate(1f); // changing the colot and using 1f bc at max health we want to display a green color
    }
    public void SetHealth(int health){ // used when the player takes damages
        txtVal.text = playerInstance.currentHealth.ToString() + "/" + playerInstance.maxHealth.ToString();
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); // changing the color when the player looses health, using "slider.normalizedValue"
                                                                // so we can use the percentages in between instead of decimals, since normally it is 0 to 1
        if(playerInstance.currentHealth == 0) {                 // when the player dies stop the game and queue the level end scene/canvas 
          //  Time.timeScale = 0f; 
            gameObject.SetActive(false);
            playerDied.SetActive(true);
            playerDied.GetComponent<PlayerDied>().Appear();
            
            }
        


    }

}
