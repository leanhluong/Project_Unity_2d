using UnityEngine;
using UnityEngine.UI;

public class BombSkillCooldown : MonoBehaviour
{
    public Image countdownImage; // Tham chiếu đến UI Image đếm ngược
    private bool isCooldown = false;

    public GameObject bombPrefab; // Prefab của quả bom
    public float bombCooldown = 2f; // Thời gian chờ giữa các lần đặt bom
    private float timeSinceLastBomb; // Biến đếm thời gian từ lần đặt bom cuối
    private UIController uI;



    void Start()
    {
        uI = FindObjectOfType<UIController>();

        // Khởi tạo timer
        countdownImage.fillAmount = 0;
    }

    void Update()
    {

        timeSinceLastBomb += Time.deltaTime;
        if (Input.GetKey(KeyCode.C) && timeSinceLastBomb >= bombCooldown && isCooldown == false)
        {
            DropBomb();
            timeSinceLastBomb = 0f;
            //cd skill
            isCooldown = true;
            countdownImage.fillAmount = 1;
        }
        // cd skill
        if (isCooldown)
        {
            countdownImage.fillAmount -= 1 / bombCooldown * Time.deltaTime;
            if(countdownImage.fillAmount <= 0)
            {
                countdownImage.fillAmount = 0;
                isCooldown = false;
            }
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
