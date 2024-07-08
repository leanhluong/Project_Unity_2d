using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Transform playerTransform;

    [SerializeField]
    int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    float tbtwTime = 2f;

    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("No player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            sr.flipX = !(Mathf.Abs(transform.position.x) - Mathf.Abs(playerTransform.position.x) > 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.GetComponent<PlayerController>().takeDame(20);

        if (collision.CompareTag("Bullet"))
        {
            takeDameEnemy(20);
            Destroy(collision.gameObject);
        }
    }

    public void takeDameEnemy(int damege)
    {
        currentHealth -= damege;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            makeDead();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    void makeDead() => Destroy(gameObject);

    private void OnTriggerStay2D(Collider2D collision)
    {
        tbtwTime -= Time.deltaTime;
        if (collision.gameObject.CompareTag("Player") && tbtwTime <= 0)
        {
            collision.gameObject.GetComponent<PlayerController>().takeDame(20);
            tbtwTime = 2;
        }
    }
}
