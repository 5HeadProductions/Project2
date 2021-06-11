using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Joystick attackJoystick;
    [SerializeField] private LineRenderer LR;
    [SerializeField] private Transform attackLookAtPoint;
    [SerializeField] private float trailDistance = 1;

    [SerializeField] private Transform player;
    private RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Abs(attackJoystick.Horizontal) > 0.5 || Mathf.Abs(attackJoystick.Vertical) > 0.5)
        {
            if (LR.gameObject.activeInHierarchy == false)
            {
                LR.gameObject.SetActive(true);
            }
            transform.position = new Vector3(player.position.x, 0, player.position.z);
            
            attackLookAtPoint.position = new Vector3(attackJoystick.Horizontal  + transform.position.x, 0f,
                attackJoystick.Vertical + transform.position.z);

            transform.LookAt(new Vector3(attackLookAtPoint.position.x, 0, attackLookAtPoint.position.z));

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            LR.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, transform.forward,out hit, trailDistance))
            {
                LR.SetPosition(1, hit.point);
            }
            else
            {
                LR.SetPosition(1, transform.position + transform.forward * trailDistance);
            }
        }
        else
        {
            LR.gameObject.SetActive(false);
        }
    }
}
