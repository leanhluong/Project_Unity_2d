using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public GameObject laserBulletPrefab; // Prefab của đạn laser
    public Transform firePoint; // Điểm xuất phát của đạn
    public float laserSpeed = 20f; // Tốc độ của đạn laser
    public float laserRange = 60f; // Phạm vi bắn của đạn laser

    public float TimeBtwFire = 0.5f; // thoi gian moi vien dan ban

    private float timebtwFire;

    private List<GameObject> activeLasers = new List<GameObject>();

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím bắn (ví dụ: phím chuột trái)

        timebtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timebtwFire < 0)
        {
            Shoot();
            timebtwFire = TimeBtwFire;
        }

        // Cập nhật vị trí của các đạn laser và kiểm tra phạm vi
        UpdateLasers();
    }

    void Shoot()
    {
        // Tạo một đạn laser mới tại vị trí firePoint
        GameObject laser = Instantiate(laserBulletPrefab, firePoint.position, firePoint.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = firePoint.right * laserSpeed;
        activeLasers.Add(laser);
    }

    void UpdateLasers()
    {
        // Lưu trữ các đạn laser đã ra khỏi phạm vi để hủy sau
        List<GameObject> lasersToRemove = new List<GameObject>();

        foreach (GameObject laser in activeLasers)
        {
            if (Vector2.Distance(firePoint.position, laser.transform.position) > laserRange)
            {
                lasersToRemove.Add(laser);
            }
        }

        // Hủy các đạn laser đã ra khỏi phạm vi
        foreach (GameObject laser in lasersToRemove)
        {
            activeLasers.Remove(laser);
            Destroy(laser);
        }
    }
}
