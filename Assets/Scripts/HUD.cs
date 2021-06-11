using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI healthTXT;

    private PlayerManager playerInstance;

    public Slider slider; //slides the health bar up and down
    public Gradient gradient; // changes the color of the slider
    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
        healthTXT.text = "Health";
        SetMaxHealth();
    }

    public void SetMaxHealth(){ // health is replenished after each level, except in hard difficulty
        slider.maxValue = playerInstance.maxHealth;
        slider.value = playerInstance.maxHealth;
        fill.color = gradient.Evaluate(1f); // changing the colot and using 1f bc at max health we want to display a green color
    }
    public void SetHealth(int health){ // used when the player takes damages
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue); // changing the color when the player looses health, using "slider.normalizedValue"
                                                                // so we can use the percentages in between instead of decimals, since normally it is 0 to 1
    }

}
