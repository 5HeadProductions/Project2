using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    [SerializeField]private PlayerMovement aiming;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3(-aiming.playerMovementDirection.position.x, 0,
            -aiming.playerMovementDirection.position.z));
        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
