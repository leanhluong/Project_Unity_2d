using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class EneShooting : MonoBehaviour
{
    public bool isShootable = false;
    public GameObject bulletPrefab; // Prefab của viên đạn
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;   
    void Start()
    {

    }
    private void Update()
    {
        fireCooldown -= Time.time;
        if( fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            Shoot();
        }
    }

    void Shoot()
    {
        var bulletTmp = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb =  bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<PlayerController>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
