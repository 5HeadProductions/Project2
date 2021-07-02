using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine. VFX;




// this script is attached to the weapons, blasterA, shoots the projectiles
public class FirePoint : MonoBehaviour
{
    public Transform firePoint; // gameobject in front of the gun where the projectile will spawn from
    public GameObject projectilePrefab; // projectile prefab
    private string shootingWith = "Fire1"; // name of the keybind the player will shoot from

    [SerializeField] private float projectileForce; // projectile speed

    [SerializeField] private GameObject player;

    [SerializeField] private Camera cam;

    public bool firing = false;
    private Animator animator;

    [SerializeField] private VisualEffect muzzleFlash;

    [SerializeField] private float attackRate = 0.5f; // the amount of time before being able to attack
    private float timeUntilAttack = 0;

    public int bulletAmmo = 0, rocketAmmo = 0; // max ammo is assigned in each gun's prefab
    public int attackDamage = 3;
    public String weaponType;
    public AudioManager audioManager;
    private PlayerManager playerInstance;
    private Inventory inventory;
    private ShopEnabler shopEnabler;
    private bool on;

    //private void Awake() => animator = player.GetComponent<Animator>(); // => is an expression body methood

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        shopEnabler = GameObject.Find("stallRed").GetComponent<ShopEnabler>();
    }

    void Update()
    {
        on = shopEnabler.shopCanvas.activeInHierarchy ? true : false;
        if (Input.GetButtonDown(shootingWith)) // button we are using to shoot 
        {
            if(on){
                 if(EventSystem.current.IsPointerOverGameObject()) return;
                }else
                {
                    if(inventory.PrimaryOn()){
                        if(inventory.RocketOn()){
                            if(playerInstance.rocketAmmo > 0){
                                Shoot();
                                playerInstance.rocketAmmo--;
                                return;
                            }
                        }
                        if(playerInstance.primaryAmmo > 0){
                        Shoot();
                        playerInstance.primaryAmmo--;
                        }
                    }else
                    {
                     if(playerInstance.secondaryAmmo > 0){
                        Shoot();
                        playerInstance.secondaryAmmo--;
                    }
                    }
                } 
        }

        //setting the bool to false so it knows to aim where the player is moving rather than firing
        //firing = false;
        //animator.SetBool("Shooting", false);

        //if statement for the purpose of making a fire rate
        if (Time.time > timeUntilAttack && bulletAmmo >= 1)
        {
           // TouchShoot();
        }



    }

    void TouchShoot()
    {
        RaycastHit hit; //stores info about the object the raycast hit
        Vector3[] touches = new Vector3[3]; //amount of touches that can be handled at a time

        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches) //does this action for each of the touches on screen currently
            {
                Ray ray = cam.ScreenPointToRay(Input.GetTouch(t.fingerId)
                    .position); //creates a ray from the touch until it hits a collider

                if (Physics.Raycast(ray, out hit, Mathf.Infinity) &&
                    Input.GetTouch(t.fingerId).phase == TouchPhase.Began &&
                    hit.collider.gameObject.CompareTag("UI") != true)
                {
                    // animator.SetBool("Shooting", true);
                    firing = true;
                    //getting the player to look at the point where the touch raycast collides with something
                    Vector3 playerLookAt = new Vector3(hit.point.x,
                        0f, hit.point.z);

                    player.transform.LookAt(playerLookAt);
                    player.transform.Rotate(new Vector3(0f, 0f, 0f));

                    //Playing audio
                    PlaySound();

                    //instantiating bullet
                    GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);

                    //adjustment for fire rate
                    timeUntilAttack = Time.time + attackRate;
                    bulletAmmo--;

                }
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        muzzleFlash.Play();
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);

    }

    private void PlaySound()
    {
        if (weaponType == "pistol" || weaponType == "Pistol")
        {
            audioManager.Play("Pistol Fire");
        }
        else if (weaponType == "rifle" || weaponType == "Rifle")
        {
            audioManager.Play("Rifle Fire");
        }
    }
    
    
}

