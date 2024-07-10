using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneSkillDash : MonoBehaviour
{
    private Transform player; // Transform của player
    public float chargeTime = 3f; // Thời gian chuẩn bị
    public float chargeSpeed = 5f; // Tốc độ húc vào player

    private bool isCharging = false; // Kiểm tra trạng thái chuẩn bị húc
    private float chargeTimer = 0f; // Bộ đếm thời gian chuẩn bị
    private Vector2 targetPosition; // Vị trí đích đã xác định trước
    private Vector2 chargeDirection; // Hướng di chuyển khi húc

    void Start()
    {
        // Tìm đối tượng player bằng tag "Player" và lấy Transform của nó
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        if (!isCharging)
        {
            chargeTimer += Time.deltaTime;

            if (chargeTimer >= chargeTime)
            {
                isCharging = true;
                chargeTimer = 0f;
                targetPosition = player.position; // Lưu lại vị trí của player tại thời điểm này
                chargeDirection = (targetPosition - (Vector2)transform.position).normalized; // Lưu lại hướng di chuyển
            }
        }
        else
        {
            ChargeAtTarget();
        }
    }

    void ChargeAtTarget()
    {
        // Di chuyển enemy về phía vị trí đã xác định với tốc độ chargeSpeed
        transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)chargeDirection, chargeSpeed * Time.deltaTime);

        // Kiểm tra nếu enemy đến gần vị trí đích, kết thúc lao
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isCharging = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với layer "Wall"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isCharging = false; // Dừng lại khi va chạm vào Wall
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().takeDame(50);


        }
        if (collision.gameObject.tag == "Bullet")
        {

            collision.gameObject.GetComponent<EnemyController>().takeDameEnemy(20);
        }
    }
}
