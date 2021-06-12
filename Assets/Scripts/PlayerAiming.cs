using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Joystick attackJoystick;
    [SerializeField] private LineRenderer LR;
    public Transform attackLookAtPoint;
    [SerializeField] private float trailDistance = 1;

    [SerializeField] private Transform player;
    private RaycastHit hit;

    [SerializeField] private float lineStartY, lineEndY;

    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 10);
    }

    void Update()
    {
        
        if (Mathf.Abs(attackJoystick.Horizontal) > 0.5 || Mathf.Abs(attackJoystick.Vertical) > 0.5)
        {
            
            if (LR.gameObject.activeInHierarchy == false)
            {
                LR.gameObject.SetActive(true);
            }
            transform.position = new Vector3(player.position.x, lineStartY, player.position.z);
            
            attackLookAtPoint.position = new Vector3(attackJoystick.Horizontal  + transform.position.x, lineEndY,
                attackJoystick.Vertical + transform.position.z);

           // transform.LookAt(new Vector3(attackLookAtPoint.position.x, lineEndY, attackLookAtPoint.position.z));

            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            LR.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, transform.forward,out hit, trailDistance))
            {
                LR.SetPosition(1, hit.point);
            }
            else
            {
                LR.SetPosition(1,  transform.forward * trailDistance);
                LR.SetPosition(1,new Vector3(LR.GetPosition(1).x, player.position.y, LR.GetPosition(1).z));
            }
        }
        else
        {
            LR.gameObject.SetActive(false);
        }
    }
}
