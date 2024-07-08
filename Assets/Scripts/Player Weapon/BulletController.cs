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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu bullet va chạm với layer Map
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            // Bạn có thể thêm các hành động như phá hủy viên đạn, tạo hiệu ứng, v.v.
            Destroy(gameObject);
        }

    }


}
