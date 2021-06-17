using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    private string sceneName1 = "TempShooting"; // name of the scene you are in
    private string sceneName2 = "TempPlay"; // name of the scene you are going to next

    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){ // using space to trigger the next scene to load, should be a button
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(sceneName2));
    }

    IEnumerator LoadLevel(string name){
        //play animation
        transition.SetTrigger("Start");// Start was set in the animator
        //wait
        yield return new WaitForSeconds(1);

        //load next scene

        SceneManager.LoadScene(name);
    }
}
