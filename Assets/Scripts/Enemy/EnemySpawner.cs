using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefabs;
    public GameObject BossPrefabs;

    // Vị trí mà enemy sẽ xuất hiện
    public Transform[] spawnPoints;
    public Transform[] spawnBossPoints;
    // Thời gian cách nhau giữa mỗi lần sinh enemy
    public float spawnDelay = 2.0f;

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

        // Spawn enemies
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabs, spawnPoints[i].position,  Quaternion.identity);
        }

        // Spawn bosses
        for (int i = 0; i < spawnBossPoints.Length; i++)
        {
            Instantiate(BossPrefabs, spawnBossPoints[i].position, Quaternion.identity);
        }
    }
}
