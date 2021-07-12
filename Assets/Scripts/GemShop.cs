using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GemShop : MonoBehaviour
{
    [Header("Background Color")]
    [SerializeField]private Image background;

    private float timeLeft;
    private Color targetColor;
    private PlayerManager playerInstance;
    [Header("Text Field")]
    [SerializeField]private TextMeshProUGUI gems_txt;

    public Button pP, pA, pS, pR, cP, cA, cS, cR;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        gems_txt.text = playerInstance.gems.ToString(); 
    }

    // Update is called once per frame
  
 
    void Update()
    {
        ChangeBGColor();
         gems_txt.text = playerInstance.gems.ToString(); 
    }
    public void ChangeBGColor(){
            if (timeLeft <= Time.deltaTime)
    {
        // transition complete
        // assign the target color
        background.color = targetColor;
 
        // start a new transition
        targetColor = new Color(Random.value, Random.value, Random.value);
        timeLeft = 1.0f;
    }
    else
    {
        // transition in progress
        // calculate interpolated color
        background.color = Color.Lerp(background.color, targetColor, Time.deltaTime / timeLeft);
 
        // update the timer
        timeLeft -= Time.deltaTime;
  }
    }
 



}
