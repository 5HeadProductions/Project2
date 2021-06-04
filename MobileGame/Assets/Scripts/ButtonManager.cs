using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private string playSceneName = "TempPlay";

    public void LoadPlay(){
        SceneManager.LoadScene(playSceneName);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


}
