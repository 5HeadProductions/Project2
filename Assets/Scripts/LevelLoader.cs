using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        Debug.Log("ENTERED");
        //play animation
        transition.SetTrigger("Start");// Start was set in the animator
        //wait
        yield return new WaitForSeconds(1f);

    }
}
