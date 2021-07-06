using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyEnabler : MonoBehaviour
{

    public GameObject difficultyCanvas;

    public int currentDungeonScene = 0;

    public GameObject mainMenu;
    // Start is called before the first frame update
    public void Awake(){
        difficultyCanvas = GameObject.Find("DifficultyCanvas");
        mainMenu = GameObject.Find("Main Menu");

        difficultyCanvas.SetActive(false);
    }

    public void TurnOn(){
        difficultyCanvas.SetActive(true);
    }

    public void TurnOnMain(){
        difficultyCanvas.SetActive(false);
        mainMenu.SetActive(true);
    }
}
