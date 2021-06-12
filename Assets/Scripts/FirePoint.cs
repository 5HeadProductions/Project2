using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

// this script is attached to the weapons, blasterA, shoots the projectiles
public class FirePoint : MonoBehaviour
{
    public Transform firePoint; // gameobject in front of the gun where the projectile will spawn from
    public GameObject projectilePrefab; // projectile prefab
    private string shootingWith = "Fire1"; // name of the keybind the player will shoot from

    [SerializeField]private float projectileForce; // projectile speed

    [SerializeField] private Transform player;

    [SerializeField] private Camera cam;

    // Update is called once per frame
    void Update()
    {

     if(Input.GetButtonDown(shootingWith)) // button we are using to shoot 
     {
      // Shoot();
     }  
     
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
                
                touches[t.fingerId] = Camera.main.ScreenToWorldPoint(Input.GetTouch(t.fingerId).position); //
                
                Ray ray = cam.ScreenPointToRay(Input.GetTouch(t.fingerId).position);//creates a ray from the touch until it hits a collider
                

               // Vector3 direction = new Vector3(touches[t.fingerId] - Camera.main.transform.position); 
                if (Input.GetTouch(t.fingerId).phase == TouchPhase.Began)
                {
                    
                    if (Physics.Raycast(ray, out hit,Mathf.Infinity))
                    {

                        
                        Debug.Log(hit.transform.position);

                        Vector3 playerLookAt = new Vector3(hit.transform.position.x,
                            hit.transform.position.y, hit.transform.position.z);
                        
                        player.transform.LookAt(playerLookAt);
                        player.transform.Rotate(new Vector3(0f, 30f, 0f));
                        
                        
                        
                        //instantiating bullet
                        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                        Rigidbody rb = bullet.GetComponent<Rigidbody>();
                        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    public void Shoot(){

       GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       Rigidbody rb = bullet.GetComponent<Rigidbody>();
       rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
     
    }
}
