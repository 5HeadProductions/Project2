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
    public Button maxHealthButton;
    public Image maxHealthCostImage;
    public TextMeshProUGUI maxHealthCoinTXT;

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
        if(playerInstance.coins >= 5){
            if(playerInstance.currentHealth < playerInstance.maxHealth){
                int addHealth = 5;
                if(slider.value + addHealth <= slider.maxValue){
                    slider.value += addHealth;
                    playerInstance.currentHealth += addHealth;
                    DisplayHealth(playerInstance.currentHealth);
                    _hud.SetHealth(playerInstance.currentHealth);
                }
                playerInstance.coins -= 5;

            }
        }

    }

    //should be called when the player buys max health
    public void IncreaseMaxHealth(){
        if(playerInstance.coins >= 100){
            int add = 10;
            if(slider.maxValue + add > 250){
                maxHealth_Txt.text = "Max Health";
                maxHealthButton.interactable = false;
                maxHealthCostImage.enabled = false;
                maxHealthCoinTXT.text = "";
                //display they can no longer upgrade their max health
            }else{
            slider.maxValue += add;
            playerInstance.maxHealth += add;
            DisplayHealth(playerInstance.currentHealth); 
            _hud.SetHealth(playerInstance.currentHealth);         
            playerInstance.coins -= 100;
            }
        }    
    }
}
