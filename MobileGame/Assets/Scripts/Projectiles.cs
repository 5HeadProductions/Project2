using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to the projectiles in the prefabs
public class Projectiles : MonoBehaviour
{

    [Range(3.0f, 20.0f)] // slider that will appear in unity
    [SerializeField]private float projectileSpeed;
    public Rigidbody rb; // rigidbody of the projectile

    public Transform projectileT; // getting the transform of the porjectile in order to rotate it

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * projectileSpeed; // "launching" the projectile forward
        projectileT.Rotate(90f, 0f, 0f, Space.Self);
        // rotating the image by 90 degrees so it the images fires straight, 
        // Space.Self rotates the transform relative to itself meaning just the game object this tranform
        // is attached to
    }


}
