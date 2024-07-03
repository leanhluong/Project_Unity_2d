using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float explosionRadius = 5f; // Bán kính phát nổ
    public LayerMask enemyLayer; // Layer của kẻ địch để kiểm tra va chạm
    public GameObject explosionEffect; // Hiệu ứng phát nổ (nếu có)

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu kẻ địch chạm vào bom
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Tạo hiệu ứng phát nổ nếu có
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 0.5f); // Tự hủy hiệu ứng phát nổ sau 0.5 giây
        }

        // Tìm tất cả các đối tượng trong bán kính phát nổ
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        // Xử lý các đối tượng bị trúng
        foreach (Collider2D enemy in hitEnemies)
        {
            // Kiểm tra nếu đối tượng có component EnemyController
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                // Gọi hàm takeDameEnemy từ EnemyController
                enemyController.takeDameEnemy(100);
            }
        }

        // Phát nổ và tự hủy quả bom
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Vẽ bán kính phát nổ khi chọn quả bom trong editor để dễ dàng điều chỉnh
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
