using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is attached to the particle system of the coins
// which will destroy the particle system once it is spawned in the scene
public class PSDestroyer : MonoBehaviour
{

    [Header("Unity Setup")]
    [SerializeField] private float time;
    void Start()
    {
        Destroy(gameObject, time);
    }


}
