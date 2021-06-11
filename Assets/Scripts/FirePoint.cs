using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is attached to the weapons, blasterA, shoots the projectiles
public class FirePoint : MonoBehaviour
{
    public Transform firePoint; // gameobject in front of the gun where the projectile will spawn from
    public GameObject projectilePrefab; // projectile prefab
    private string shootingWith = "Fire1"; // name of the keybind the player will shoot from

    [SerializeField]private float projectileForce; // projectile speed

    // Update is called once per frame
    void Update()
    {

     if(Input.GetButtonDown(shootingWith)) // button we are using to shoot 
     {
        Shoot();
     }  

    }

    public void Shoot(){
       GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       Rigidbody rb = bullet.GetComponent<Rigidbody>();
       rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
    }
}
