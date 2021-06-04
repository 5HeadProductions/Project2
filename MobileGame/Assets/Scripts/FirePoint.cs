using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is attached to the weapons, blasterA
public class FirePoint : MonoBehaviour
{
    public Transform firePoint; // gameobject in front of the gun where the projectile will spawn from
    public GameObject projectile; // projectile prefab
    private string shootingWith = "Fire1"; // name of the keybind the player will shoot from

    // Update is called once per frame
    void Update()
    {

     if(Input.GetButtonDown(shootingWith)) // button we are using to shoot 
     {
        Shoot();
     }  

    }

    public void Shoot(){
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
