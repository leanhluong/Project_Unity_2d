using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefabs; 
    public GameObject enemyShootPrefabs;
    public GameObject BossPrefabs;
    public GameObject explosionPrefab;  // Prefab của hiệu ứng nổ


    public float spawnRate = 1.5f; //time spwaner
    public float spawnRadius = 7f;
    private float spawnTimer = 0f;
    private float spawnTimers = 0f;


    private float countEnemyBorn = 0f;

    private UIController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnRate)
        {
            SpawnExplosion();

            spawnTimer = 0f;

        }
        //if (countEnemyBorn >= 3f)
        //{
        //    SpawnEnemyShoot();

        //}
        spawnTimers += Time.deltaTime;
        if (spawnTimers >= 5f)
        {
            SpawnBoss();

            spawnTimers = 0f;
        }
    }
    void SpawnExplosion()
    {
        //Vector3 spawnPos = transform.position;

        //GameObject explosion = Instantiate(explosionPrefab, spawnPos, transform.rotation);

        //Destroy(explosion, 1f); // Tự hủy hiệu ứng phát nổ sau 2 giây (thời gian animation)
        
        Invoke("SpawnEnemy", 1f);
    
    }
    void SpawnEnemy()
    {

        Vector2 spawnPos = RandomCircleEdgePosition(spawnRadius);

        Instantiate(enemyPrefabs, spawnPos, Quaternion.identity);

        controller.IncrementEnemyCount();

        countEnemyBorn++;
    }
    void SpawnBoss()
    {
        Vector2 spawnPos = RandomCircleEdgePosition(spawnRadius);
        Instantiate(BossPrefabs, spawnPos, Quaternion.identity);

    }
    void SpawnEnemyShoot()
    {
        Vector2 spawnPos = RandomCircleEdgePosition(spawnRadius);
        Instantiate(enemyShootPrefabs, spawnPos, Quaternion.identity);

    }

    private Vector2 RandomCircleEdgePosition(float radius)
    {
        // Tạo góc ngẫu nhiên trên đường tròn
        float angle = Random.Range(0f, 2f * Mathf.PI);

        // Tính toán vị trí trên rìa vòng tròn dựa vào góc ngẫu nhiên
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        return new Vector2(x, y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
