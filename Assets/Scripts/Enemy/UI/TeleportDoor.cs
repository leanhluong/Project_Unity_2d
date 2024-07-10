using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public Transform destination; // Vị trí đích để dịch chuyển tới
    private bool isTeleporting = false; // Để ngăn dịch chuyển liên tục

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            StartCoroutine(Teleport(other));
        }
    }

    private IEnumerator Teleport(Collider2D player)
    {
        isTeleporting = true;

        // Dịch chuyển người chơi đến vị trí đích
        player.transform.position = destination.position;

        // Đợi một khoảng thời gian để tránh việc dịch chuyển liên tục
        yield return new WaitForSeconds(1f);

        isTeleporting = false;
    }
}
