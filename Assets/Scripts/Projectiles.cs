using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script is attached to the projectiles in the prefabs
//the projectiles are shot in the FirePoint scripts

public class Projectiles : MonoBehaviour
{
    private PlayerManager playerInstance;
    
    [Range(3.0f, 20.0f)] // slider that will appear in unity
    [SerializeField]private float projectileSpeed;
    public Rigidbody rb; // rigidbody of the projectile
    public Transform projectileT; // getting the transform of the porjectile in order to rotate it
    public float attackDamage = 3.0f; // should change depending on what gun the player is using
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * projectileSpeed; // "launching" the projectile forward
        projectileT.Rotate(90f, 0f, 0f, Space.Self);
        // rotating the image by 90 degrees so it the images fires straight, 
        // Space.Self rotates the transform relative to itself meaning just the game object this tranform
        // is attached to
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }

    }

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Zombie")){
           // Vector3 hitPosition = col.gameObject.GetComponent<Transform>().position; // the animation recoding has a set position
            Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // the animation recoding has a set position
            

            GameObject coinBlood = Instantiate(coinPrefab, spawnPosition, coinPrefab.GetComponent<Transform>().rotation);
           
           
            Instantiate(particles,transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles, .5f);
            Destroy(coinBlood, .5f);
            col.gameObject.GetComponent<BasicEnemyBehavior>().reduceHealth(attackDamage); 
            playerInstance.coins ++;
            Destroy(gameObject);
        }
        else
        {
            //add particles like sparks bc it didnt hit zombie
            Destroy(gameObject);
        }

    }


}
