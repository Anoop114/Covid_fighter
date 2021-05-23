using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject bulletPrefeb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") && player_bullet.bullet>0){
            shoot();
        }
    }
    void shoot(){
        Instantiate(bulletPrefeb,fire_point.position,fire_point.rotation);
    }
}
