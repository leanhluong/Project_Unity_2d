using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneShotV2_3v : MonoBehaviour
{
    public GameObject bulletPrefab; // Đối tượng Prefab đạn
    public float shootingRange = 5f; // Phạm vi bắn
    public float shootingInterval = 0.2f; // Khoảng thời gian giữa các lần bắn đạn
    public float moveSpeed = 5f; // Tốc độ di chuyển của enemy
    private Transform player; // Transform của player
    private float shootingTimer; // Bộ đếm thời gian cho việc bắn
    private int bulletsShot = 0; // Số đạn đã bắn trong đợt bắn hiện tại
    private float reloadTime = 3f; // Thời gian nạp lại giữa các đợt bắn
    private float reloadTimer = 0f; // Bộ đếm thời gian nạp lại

    void Start()
    {
        // Tìm đối tượng player bằng tag "Player" và lấy Transform của nó
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

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
            HandleShooting();
        }
        // Nếu player ngoài phạm vi bắn, di chuyển lại gần player
        else
        {
            MoveTowardsPlayer();
        }
    }

    void HandleShooting()
    {
        if (reloadTimer > 0)
        {
            // Giảm bộ đếm thời gian nạp lại
            reloadTimer -= Time.deltaTime;
        }
        else
        {
            // Kiểm tra nếu đã đến thời gian để bắn
            if (shootingTimer <= 0f)
            {
                ShootAtPlayer();
                bulletsShot++;

                // Nếu đã bắn đủ 3 viên, đặt lại số đạn đã bắn và khởi động lại bộ đếm thời gian nạp lại
                if (bulletsShot >= 3)
                {
                    bulletsShot = 0;
                    reloadTimer = reloadTime;
                }

                // Đặt lại bộ đếm thời gian giữa các lần bắn
                shootingTimer = shootingInterval;
            }
            else
            {
                // Giảm bộ đếm thời gian giữa các lần bắn
                shootingTimer -= Time.deltaTime;
            }
        }
    }

    void ShootAtPlayer()
    {
        // Tính hướng bắn
        Vector2 direction = (player.position - transform.position).normalized;
        // Tạo đạn tại vị trí của enemy
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // Đặt vận tốc cho đạn
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; // tốc độ đạn
    }

    void MoveTowardsPlayer()
    {
        // Tính hướng di chuyển
        Vector2 direction = (player.position - transform.position).normalized;
        // Di chuyển enemy về phía player
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
