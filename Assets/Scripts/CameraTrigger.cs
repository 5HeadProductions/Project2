using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //meant to be attached to an empty object with a trigger box collider that will snap the camera to the position it is given
    [SerializeField]private Transform cameraPlacement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.transform.position = cameraPlacement.position;
            Camera.main.transform.rotation = cameraPlacement.rotation;
        }
    }
}
