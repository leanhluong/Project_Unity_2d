using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.5f; // thoi gian moi vien dan ban
    public float bulletSpeed = 9;// toc do dan

    private float timebtwFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GunRotation();
        timebtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timebtwFire < 0)
        {
            FireBullet();
        }
    }

    void GunRotation()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 lookDir = mousePos - transform.position;

        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //Quaternion rotation = Quaternion.Euler(0,0,angle);
        //transform.rotation = rotation;

        //if(transform.eulerAngles.z > 90 &&  transform.eulerAngles.z < 270)
        //{
        //    transform.localScale = new Vector3(0.05f, -0.05f, 0);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(0.05f, 0.05f, 0);
        //}
    }
    void FireBullet()
    {
        timebtwFire = TimeBtwFire;

        GameObject bullets = Instantiate(bullet, firePos.position, transform.rotation);

        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
