using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefabs;
    public GameObject BossPrefabs;


    // Vị trí mà enemy sẽ xuất hiện
    public Transform[] spawnPoints;
    public Transform bossSpawnPoint;
    // Thời gian cách nhau giữa mỗi lần sinh enemy
    public float spawnDelay = 2.0f;

    // Số lượng enemy sẽ sinh ra
    public int enemyCount = 5;

    private UIController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Kiểm tra player vào vùng kích hoạt
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Sinh ra enemy
            SpawnEnemiesAndBossCoroutine();
            // Vô hiệu hóa vùng kích hoạt sau khi sinh ra enemy
            gameObject.SetActive(false);
        }
    }

    private void SpawnEnemiesAndBossCoroutine()
    {
        if (spawnPoints.Length < 3)
        {
            Debug.LogError("Không đủ vị trí spawn (cần ít nhất 3).");

        }

        // Sinh ra 2 enemy tại 2 vị trí đầu tiên
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyPrefabs, spawnPoints[i].position, Quaternion.identity);

        }

        // Sinh ra boss tại vị trí xác định
        Instantiate(BossPrefabs, bossSpawnPoint.position, Quaternion.identity);
    }
}
