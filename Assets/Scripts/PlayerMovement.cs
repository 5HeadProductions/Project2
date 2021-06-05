using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask _aimLayerMask;

    private Animator _animator;

    public Joystick joystick;

    private void Awake() => _animator = GetComponent<Animator>(); // => is an expression body methood

    private void Update()
    {
        //AimTowardsMouse();
        
        //reading Input for keyboard
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        
        //Moving
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        
        //_animator.SetFloat("VelocityZ", velocityZ, 0.1f,Time.deltaTime);
        //_animator.SetFloat("VelocityX", velocityX, 0.1f,Time.deltaTime);
    }

    private void AimTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _aimLayerMask))
        {
            var _direction = hitInfo.point - transform.position;
            _direction.y = 0f;
            _direction.Normalize();
            transform.forward = _direction;
        }
    }
}