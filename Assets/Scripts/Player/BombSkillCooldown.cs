using UnityEngine;
using UnityEngine.UI;

public class BombSkillCooldown : MonoBehaviour
{
    public Image countdownImage; // Tham chiếu đến UI Image đếm ngược
    public float cooldownTime = 2f; // Thời gian hồi chiêu
    private float cooldownTimer;
    private bool isCooldown = false;

    public GameObject bombPrefab; // Prefab của quả bom
    public float bombCooldown = 2f; // Thời gian chờ giữa các lần đặt bom
    private float timeSinceLastBomb; // Biến đếm thời gian từ lần đặt bom cuối
    private UIController uI;

    void Start()
    {
        uI = FindObjectOfType<UIController>();

        // Khởi tạo timer
        cooldownTimer = cooldownTime;
    }

    void Update()
    {
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            UpdateCountdownImage();

            if (cooldownTimer <= 0)
            {
                isCooldown = false;
                cooldownTimer = cooldownTime; // Đặt lại timer khi hết thời gian hồi chiêu
                UpdateCountdownImage();
            }
        }

        // Cập nhật thời gian
        timeSinceLastBomb += Time.deltaTime;

        if (Input.GetKey(KeyCode.I) && timeSinceLastBomb >= cooldownTime)
        {
            DropBomb();
            StartCooldown();

            timeSinceLastBomb = 0f;
        }
    }

    void UpdateCountdownImage()
    {
        float fillAmount = cooldownTimer / cooldownTime;
        countdownImage.fillAmount = fillAmount;
    }

    public void StartCooldown()
    {
        if (!isCooldown)
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }

    void DropBomb()
    {
        // Lấy vị trí hiện tại của player
        Vector3 bombPosition = transform.position;

        // Sinh ra quả bom tại vị trí đó
        Instantiate(bombPrefab, bombPosition, Quaternion.identity);
    }
}
