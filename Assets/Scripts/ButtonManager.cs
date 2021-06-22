using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string playSceneName = "TempPlay";
    private string weaponScene = "TempShooting";
    private string main = "MainMenu";

    private WeaponHolder weaponHolder;
        // Start is called before the first frame update
    void Start()
    {
        weaponHolder = GameObject.Find("Weapon Holder").GetComponent<WeaponHolder>();
    }
    
    public void LoadMainMenu(){
        SceneManager.LoadScene(main);
    }

    public void LoadPlay(){
        SceneManager.LoadScene(playSceneName);
    }

    public void LoadWeapons(){
        SceneManager.LoadScene(weaponScene);
    }

    public void DefaultAREquip()
    {
        if (GameObject.FindGameObjectWithTag("Primary") != null)        //if there is a different primary equipped then destroy it
        {
            
            Destroy(GameObject.FindGameObjectWithTag("Primary"));
            
        }
        
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[0], weaponHolder.Weapons[0].transform.position, //Instantiate a clone of wanted weapon
                weaponHolder.Weapons[0].transform.rotation);
        Debug.Log(weaponHolder.player.transform.position);
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon
       
        weaponClone.transform.position = weaponHolder.ARVector;   //assigning the newly spawned weapon The ARVector (position)
        
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
        
        
        
    }
    
    




}
