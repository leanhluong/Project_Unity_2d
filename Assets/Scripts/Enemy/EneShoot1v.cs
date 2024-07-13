using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneShoot1v : MonoBehaviour
{
    // Đối tượng Prefab đạn
    public GameObject bulletPrefab;
    // Phạm vi bắn
    public float shootingRange = 5f;
    // Khoảng thời gian giữa các lần bắn
    public float shootingInterval = 1f;
    // Tốc độ di chuyển của enemy
    public float moveSpeed = 2f;
    // Transform của player
    private Transform player;
    // Bộ đếm thời gian cho việc bắn
    private float shootingTimer;

    // Khởi tạo
    void Start()
    {
        // Tìm đối tượng player bằng tag "Player" và lấy Transform của nó
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Cập nhật mỗi frame
    void Update()
    {
        // Nếu player không tồn tại, thoát ra để tránh lỗi
        if (player == null)
            return;

        // Tính khoảng cách từ enemy đến player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Nếu player trong phạm vi bắn, gọi hàm bắn
        if (distanceToPlayer <= shootingRange)
        {
            ShootAtPlayer();
        }
        // Nếu player ngoài phạm vi bắn, di chuyển lại gần player
        else
        {
            MoveTowardsPlayer();
        }
    }

    // Hàm bắn đạn về phía player
    void ShootAtPlayer()
    {
        // Kiểm tra nếu đã đến thời gian để bắn
        if (shootingTimer <= 0f)
        {
            // Tính hướng bắn
            Vector2 direction = (player.position - transform.position).normalized;
            // Tạo đạn tại vị trí của enemy
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // Đặt vận tốc cho đạn
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; // tốc độ đạn
            // Reset bộ đếm thời gian
            shootingTimer = shootingInterval;
        }
        else
        {
            // Giảm bộ đếm thời gian
            shootingTimer -= Time.deltaTime;
        }
    }

    // Hàm di chuyển lại gần player
    void MoveTowardsPlayer()
    {
        // Tính hướng di chuyển
        Vector2 direction = (player.position - transform.position).normalized;
        // Di chuyển enemy về phía player
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
