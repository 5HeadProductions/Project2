using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f, circleSpriteY;
    [SerializeField] public Transform playerMovementDirection;

    private Animator _animator;
    

    public Joystick movementJoystick;
    
    private void Awake() => _animator = GetComponent<Animator>(); // => is an expression body methood

    private void LateUpdate()
    {
        playerMovementDirection.position = new Vector3(movementJoystick.Horizontal + transform.position.x,
                circleSpriteY, movementJoystick.Vertical + transform.position.z);

            
            
        Vector3 movement = new Vector3(movementJoystick.Horizontal, 0f, movementJoystick.Vertical);

        
        
        //Moving
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
            _animator.SetBool("moving", true);
            
            //transform.LookAt(new Vector3(playerMovementDirection.position.x, 0, playerMovementDirection.position.z));

            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
        
        
        

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        
        //_animator.SetFloat("VelocityZ", velocityZ, 0.1f,Time.deltaTime);
        //_animator.SetFloat("VelocityX", velocityX, 0.1f,Time.deltaTime);
    }
    
}