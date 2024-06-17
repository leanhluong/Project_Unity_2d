using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public GameObject ghostEffect;
    public float timeGhost;
    public Coroutine dashEffectCoroutine;

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
        PlayerMoving();

        // Cập nhật thời gian
        timeSinceLastBomb += Time.deltaTime;
        // Cập nhật UI Slider với thời gian còn lại để tái sử dụng bom
        float cooldownRemaining = Mathf.Max(0f, bombCooldown - timeSinceLastBomb);
        cooldownSlider.value = cooldownRemaining;

        if (Input.GetKey(KeyCode.I) &&timeSinceLastBomb >= bombCooldown)
        {
            DropBomb();
            timeSinceLastBomb = 0f;
        }        
        
        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false)
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();
        } 
        if(_dashTime <= 0 && isDashing == true)
        {
            speed -= dashBoost;
            isDashing = false ;
            StopDashEffect();
        } else
        {
            _dashTime -= Time.deltaTime;
        }

    }

    void PlayerMoving()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.position += moveInput * speed * Time.deltaTime;
        //if (moveInput.x != 0 || moveInput.y != 0)
        //{
        //    if (moveInput.x > 0)
        //    {
        //        gameObject.transform.localScale = new Vector3(3, 3, 1);
        //    }

        //    else if (moveInput.x < 0)
        //    {
        //        gameObject.transform.localScale = new Vector3(-3, 3, 1);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.A))
        //{

        //} else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.A))
        //{

        //}else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
        //{

        //}else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        //{

        //}
        //else
        //{

        //}
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
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Ondeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        Destroy(gameObject);
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

    void StopDashEffect()
    {
        if(dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }

    void StartDashEffect()
    {
        if(dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }

    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);

            yield return new WaitForSeconds(timeGhost);
        }
    }

}
