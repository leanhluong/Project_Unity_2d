using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public GameObject laserSegmentPrefab; // Prefab của đoạn laser
    public Transform firePoint; // Điểm xuất phát của đoạn laser
    public float laserRange = 10f; // Phạm vi bắn của đoạn laser

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím bắn (ví dụ: phím chuột trái)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo một đoạn laser mới tại vị trí firePoint
        GameObject laserSegment = Instantiate(laserSegmentPrefab, firePoint.position, firePoint.rotation);
        MagicLazer magicLazer = laserSegment.GetComponent<MagicLazer>();
        if (magicLazer != null)
        {
            magicLazer.UpdateLaserRange(laserRange);
        }
    }
}
