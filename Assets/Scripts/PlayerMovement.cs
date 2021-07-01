using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f, circleSpriteY;
    [SerializeField] public Transform playerMovementDirection;
    [SerializeField] private LayerMask _aimLayerMask;
    [SerializeField] public FirePoint firePoint;


private Animator _animator;

[SerializeField] private Vector3 _aimOffset;
    

    private void Awake(){
     _animator = GetComponent<Animator>(); // => is an expression body methood\
     
    }
    
    

    private void Update()
    {
        AimTowardsMouse();
        //moving the little sprite that should be in front of the player at all times
        

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        playerMovementDirection.position = new Vector3(horizontal + transform.position.x,
            circleSpriteY, vertical + transform.position.z);
        
        //getting input from the movement joystick
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        
        //Moving
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
            _animator.SetBool("moving", true);
            //so the player can look at the firing position momentarily
            
        }
        else
        {
            _animator.SetBool("moving", false);
        }

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }


    void AimTowardsMouse()
    {
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask))
        {
            var _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            
            transform.forward = _direction;
            transform.Rotate(_aimOffset);
        }
    }
}