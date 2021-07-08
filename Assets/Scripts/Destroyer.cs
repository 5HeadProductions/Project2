using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Destroys other Room spawn points so it does not spawn a double room
    private void OnTriggerEnter(Collider other)
    {
    if(other.CompareTag("RoomSpawnPoint")){
        Destroy(other.gameObject);
    }
    }
}
