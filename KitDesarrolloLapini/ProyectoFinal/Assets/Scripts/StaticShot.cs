using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticShot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletOffset;
    public float fireDelay;
    float cooldownTimer = 0f;
    public int bulletSpeed;
    public Transform finalPos;


    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if(cooldownTimer > fireDelay)
        {
            cooldownTimer = 0f;
            Vector3 offset = transform.position + bulletOffset * transform.up;
            GameObject bulletClone = Instantiate(bullet, offset, transform.rotation) as GameObject;
            bulletClone.GetComponent<BulletProperties>().finalPos = finalPos;
            bulletClone.GetComponent<BulletProperties>().speed = bulletSpeed;
        }
    }
}
