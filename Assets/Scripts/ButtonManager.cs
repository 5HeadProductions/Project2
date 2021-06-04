using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private string playSceneName = "TempPlay";
    private string weaponScene = "TempShooting";

    public void LoadPlay(){
        SceneManager.LoadScene(playSceneName);
    }

    public void LoadWeapons(){
        SceneManager.LoadScene(weaponScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


}
