using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine. VFX;

// this script is attached to the weapons, blasterA, shoots the projectiles
public class FirePoint : MonoBehaviour
{
    public Transform firePoint; // gameobject in front of the gun where the projectile will spawn from
    public GameObject projectilePrefab; // projectile prefab
    private string shootingWith = "Fire1"; // name of the keybind the player will shoot from

    [SerializeField]private float projectileForce; // projectile speed

    [SerializeField] private GameObject player;

    [SerializeField] private Camera cam;

    public bool firing = false;
    private Animator animator;

    [SerializeField] private VisualEffect muzzleFlash;

    //private void Awake() => animator = player.GetComponent<Animator>(); // => is an expression body methood

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    void Update()
    {

     if(Input.GetButtonDown(shootingWith)) // button we are using to shoot 
     {
    Shoot();
     }

     //setting the bool to false so it knows to aim where the player is moving rather than firing
         //firing = false;
         //animator.SetBool("Shooting", false);
         TouchShoot();
         
     

    }

    void TouchShoot()
    {
        
        
        RaycastHit hit;   //stores info about the object the raycast hit
        Vector3[] touches = new Vector3[3]; //amount of touches that can be handled at a time
        
        if(Input.touchCount > 0)
        {
            foreach(Touch t in Input.touches) //does this action for each of the touches on screen currently
            {
                Ray ray = cam.ScreenPointToRay(Input.GetTouch(t.fingerId).position);//creates a ray from the touch until it hits a collider
                
                if (Physics.Raycast(ray, out hit,Mathf.Infinity) && Input.GetTouch(t.fingerId).phase == TouchPhase.Began && hit.collider.gameObject.CompareTag("UI") != true)
                {
                   // animator.SetBool("Shooting", true);
                    firing = true;
                        //getting the player to look at the point where the touch raycast collides with something
                        Vector3 playerLookAt = new Vector3(hit.point.x,
                            0f, hit.point.z);
                    
                        player.transform.LookAt(playerLookAt);
                        player.transform.Rotate(new Vector3(0f, 0f, 0f));
                        
                        //instantiating bullet
                        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                        Rigidbody rb = bullet.GetComponent<Rigidbody>();
                        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
                }
            }
        }
    }

    public void Shoot(){

       GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       Rigidbody rb = bullet.GetComponent<Rigidbody>();
       muzzleFlash.Play();
       rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
     
    }
}
