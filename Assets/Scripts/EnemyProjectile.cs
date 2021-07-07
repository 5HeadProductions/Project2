using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script is attached to the projectiles in the prefabs
//the projectiles are shot in the FirePoint scripts

public class EnemyProjectile : MonoBehaviour
{
    private PlayerManager playerInstance;
    
    [Range(3.0f, 20.0f)] // slider that will appear in unity
    [SerializeField]private float projectileSpeed;
    public Rigidbody rb; // rigidbody of the projectile
    public Transform projectileT; // getting the transform of the porjectile in order to rotate it
    public int attackDamage = 3; // should change depending on what gun the player is using
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private ParticleSystem particles;
    public HUD _hud; // HUD script
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * projectileSpeed; // "launching" the projectile forward
        
        if(GameObject.Find("PlayerManager")!= null){
            playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        }
        _hud = GameObject.Find("HealthBar").GetComponent<HUD>();

    }

    public void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Zombie")){
            
            Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // the animation recoding has a set position
            

          //  GameObject coinBlood = Instantiate(coinPrefab, spawnPosition, coinPrefab.GetComponent<Transform>().rotation);
           
           
          // var particleClone =  Instantiate(particles,transform.position, Quaternion.identity); //storing particle Clone so we dont delete the passed in prefab
            //particles.Play();
            //Destroy(particleClone, .5f);
           // Destroy(coinBlood, .5f);
            col.gameObject.GetComponent<BasicEnemyBehavior>().reduceHealth(attackDamage);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            playerInstance.currentHealth -= attackDamage;  // lowering the players current health
            _hud.SetHealth(playerInstance.currentHealth);
            Destroy(gameObject);
        }
        else
        {
            //add particles like sparks bc it didnt hit zombie
            
            Destroy(gameObject);
        }

    }


}
