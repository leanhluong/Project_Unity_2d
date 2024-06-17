using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEne : MonoBehaviour
{
    public float timeDie = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().takeDame(20);

        }
    }
}
