using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]private Transform cameraPlacement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yo mom");
            Camera.main.transform.position = cameraPlacement.position;
            Camera.main.transform.rotation = cameraPlacement.rotation;
        }
    }
}
