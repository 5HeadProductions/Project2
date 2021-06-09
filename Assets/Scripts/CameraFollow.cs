using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script should be attached to camera
public class CameraFollow : MonoBehaviour
{
    public Transform target;  //transform that will be followed by camera
    
    public float smoothSpeed = 1f; //Should only be between 0 and 1
    public Vector3 offset;
    
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; //smoothing, unsure why it works 
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Lerping makes it so it moves the smoothSpeed(amount) each frame, if one it would move to the desired position in one frame
        //if .5 it would move halfway there in 1 frame
        transform.position = smoothedPosition;
        
        
        transform.LookAt(target);
    }
}
