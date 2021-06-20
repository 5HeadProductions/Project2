using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Animator animator;
    public GameObject zombie;
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1);
    }

    public void SetHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (slider.value == 0)
        {
            animator.SetBool("Dead", true);
        }

        Destroy(zombie, 5f);

    }
}
