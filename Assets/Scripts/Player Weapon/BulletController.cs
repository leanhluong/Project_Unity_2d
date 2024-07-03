using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float timeDie = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDie);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
