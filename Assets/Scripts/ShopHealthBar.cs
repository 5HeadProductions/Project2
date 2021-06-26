using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopHealthBar : MonoBehaviour
{
    public Slider slider; //slides the health bar up and down
    public Gradient gradient; // changes the color of the slider
    public Image fill;
    private PlayerManager playerInstance;
    [SerializeField]private TextMeshProUGUI currentHealth_Txt, maxHealth_Txt;

    private HUD _hud;
    void OnEnable(){
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            }
        _hud = GameObject.Find("HealthBar").GetComponent<HUD>();
        DisplayHealth(playerInstance.currentHealth);

    }

    // DisplayHealth displays the current health the player has
    public void DisplayHealth(int health){      
        currentHealth_Txt.text = playerInstance.currentHealth.ToString() + "/" + playerInstance.maxHealth.ToString();
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); // changing the color when the player looses health, using "slider.normalizedValue"
                                                                // so we can use the percentages in between instead of decimals, since normally it is 0 to 1
                                                                // when the player dies stop the game and queue the level end scene/canvas 
    }

    public void Heal(){
        int addHealth = 5;
        if(slider.value + addHealth <= slider.maxValue){
            slider.value += addHealth;
            playerInstance.currentHealth += addHealth;
            DisplayHealth(playerInstance.currentHealth);
            _hud.SetHealth(playerInstance.currentHealth);
        }

    }

    //should be called when the player buys max health
    public void IncreaseMaxHealth(){    
        int add = 10;
        if(slider.maxValue + add > 250){
            maxHealth_Txt.text = "Max Health";
            //display they can no longer upgrade their max health
        }else{
        slider.maxValue += add;
        playerInstance.maxHealth += add;
        DisplayHealth(playerInstance.currentHealth); 
        _hud.SetHealth(playerInstance.currentHealth);         
       // currentHealth_Txt.text = playerInstance.maxHealth.ToString() + "/" + playerInstance.maxHealth.ToString();
       // slider.maxValue = playerInstance.maxHealth; // this needs to be changed when the player buys max value health
       // playerInstance.currentHealth = playerInstance.maxHealth; // gives more max health to the player and heals them
      //  slider.value = playerInstance.maxHealth; // displays the player has max health when they buy extra health
      //  fill.color = gradient.Evaluate(1f); // changing the color and using 1f bc at max health we want to display a green color
        }
    }
}
