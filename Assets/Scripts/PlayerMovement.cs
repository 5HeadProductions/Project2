using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float _speed = 5.0f, circleSpriteY;
    [SerializeField] public Transform playerMovementDirection;
    [SerializeField] private LayerMask _aimLayerMask;
    public FirePoint firePoint;


private Animator _animator;

[SerializeField] private Vector3 _aimOffset;
 private PlayerManager playerInstance;   

    private void Awake(){
     _animator = GetComponent<Animator>(); // => is an expression body methood\
   //  firePoint = GameObject.GetComponentInChildren<FirePoint>();'
    playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
     
    }
    
    

    private void Update()
    {
        AimTowardsMouse();
        //moving the little sprite that should be in front of the player at all times

        if(playerInstance.movementMulti <= 3){ // keeps track of how many times the player has bought the speed item
           
            UpdateSpeed();
        }
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

// updating the player speed when the player purchases the ability in the shop
// the player can upgrade their speed up to 3 time hence why the switch statement only goes up to 3
// player default speed is 5
    void UpdateSpeed(){ 
        switch(playerInstance.movementMulti){   
            case 0: // default speen used
            break;
            case 1: // when the player only buys the item once then 
            _speed = _speed < 6.5f ? _speed += 1.5f :  _speed += 0.0f;//if the player speed is less than the default + 1.5 then add 1.5 to default else don't change it 
          break;
            case 2: // the second time it is bought 
            _speed = _speed < 8.0f ? _speed += 1.5f :  _speed += 0.0f;//if the player speed is less than the previous upgrade speed + 1.5 then add them else don't change it
            break;
            case 3:
            _speed = _speed < 9.5f ? _speed += 1.0f :  _speed += 0.0f;
           break;
        }

    }
}