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
    public void DefaultPistoEquip() // this is for the HUDUI canvas
    {
        if (GameObject.FindGameObjectWithTag("Primary") != null)        //if there is a different primary equipped then destroy it
        {    
            Destroy(GameObject.FindGameObjectWithTag("Primary"));  
        }
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[0], weaponHolder.Weapons[0].transform.position, //Instantiate a clone of wanted weapon
                weaponHolder.Weapons[0].transform.rotation);
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon
       
        weaponClone.transform.position = weaponHolder.ARVector + weaponHolder.player.transform.position;   //assigning the newly spawned weapon The ARVector (position)
        
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
 
    }

    public void DefaultAREquip() // this is for the HUDUI canvas
    {
        //switch statements
      //  Equip(1);
 
    }
    public void Equip(int num) // this is for the HUDUI canvas
    {
        if (GameObject.FindGameObjectWithTag("Primary") != null)        //if there is a different primary equipped then destroy it
        {    
            Destroy(GameObject.FindGameObjectWithTag("Primary"));  
        }
        GameObject weaponClone = Instantiate(weaponHolder.Weapons[num], weaponHolder.Weapons[num].transform.position, //Instantiate a clone of wanted weapon
                weaponHolder.Weapons[num].transform.rotation);
        weaponClone.transform.parent = weaponHolder.player.transform; //player gets child: weapon
       
        weaponClone.transform.position = weaponHolder.ARVector + weaponHolder.player.transform.position;   //assigning the newly spawned weapon The ARVector (position)
        
        weaponClone.GetComponentInChildren<FirePoint>().enabled = true; //firepoint is turned on bc it is off on the prefabs
 
    }
    
    




}
