using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    //holds our weapons so we can call them in button manager
    public GameObject player;
    public GameObject[] Weapons;
    public Sprite[] weaponSprites;
    
    public Vector3 ARVector = new Vector3(0.239999995f, 1.98479891f, 0.685321569f);

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
}
