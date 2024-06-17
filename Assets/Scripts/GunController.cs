using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.5f;
    public float bulletForce = 9;

    //public float speed = 20f;
    public Vector3 moveInput;

    private float timebtwFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal");
        //moveInput.y = Input.GetAxis("Vertical");

        //transform.position += moveInput * speed * Time.deltaTime;
        GunRotation();
        timebtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timebtwFire < 0)
        {
            FireBullet();
        }
    }

    void GunRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0,0,angle);
        transform.rotation = rotation;

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

        GameObject bullets = Instantiate(bullet, firePos.position, Quaternion.identity);

        Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
