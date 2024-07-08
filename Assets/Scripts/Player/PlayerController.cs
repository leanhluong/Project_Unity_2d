using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public Vector3 moveInput;

    public GameObject bombPrefab; // Prefab của quả bom
    public float bombCooldown = 2f; // Thời gian chờ giữa các lần đặt bom
    private float timeSinceLastBomb; // Biến đếm thời gian từ lần đặt bom cuối
    public Slider cooldownSlider; // Tham chiếu đến UI Slider để hiển thị thời gian hồi chiêu

    [SerializeField]
    int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public UnityEvent Ondeath;
    // Start is called before the first frame update
    private UIController uI;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    //public GameObject ghostEffect;
    //public float timeGhost;
    //public Coroutine dashEffectCoroutine;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        uI = FindObjectOfType<UIController>();
        // Thiết lập giá trị tối đa của Slider là thời gian hồi chiêu
        cooldownSlider.maxValue = bombCooldown;
        // Đặt giá trị ban đầu của Slider
        cooldownSlider.value = bombCooldown;

        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        // Cập nhật thời gian
        timeSinceLastBomb += Time.deltaTime;
        // Cập nhật UI Slider với thời gian còn lại để tái sử dụng bom
        float cooldownRemaining = Mathf.Max(0f, bombCooldown - timeSinceLastBomb);
        cooldownSlider.value = cooldownRemaining;

        if (Input.GetKey(KeyCode.I) && timeSinceLastBomb >= bombCooldown)
        {
            DropBomb();
            timeSinceLastBomb = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false)
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;

        }
        if (_dashTime <= 0 && isDashing == true)
        {
            speed -= dashBoost;
            isDashing = false;

        }
        else
        {
            _dashTime -= Time.deltaTime;
        }

    }

    float moveX = 0f;
    float moveY = 0f;

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (moveX == 0f && moveY == 0f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(moveX * speed, moveY * speed);
        }
    }

    void DropBomb()
    {
        // Lấy vị trí hiện tại của player
        Vector3 bombPosition = transform.position;

        // Sinh ra quả bom tại vị trí đó
        Instantiate(bombPrefab, bombPosition, Quaternion.identity);
    }
    public void takeDame(int damege)
    {
        currentHealth -= damege;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Ondeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        uI.GameOver();
    }

    private void OnEnable()
    {
        Ondeath.AddListener(Death);
    }
    private void OnDisable()
    {
        Ondeath.RemoveListener(Death);
    }

    //void StopDashEffect()
    //{
    //    if(dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    //}

    //void StartDashEffect()
    //{
    //    if(dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    //    dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    //}

    //IEnumerator DashEffectCoroutine()
    //{
    //    while (true)
    //    {
    //        GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);

    //        yield return new WaitForSeconds(timeGhost);
    //    }
    //}

}
