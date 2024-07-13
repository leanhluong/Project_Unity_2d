using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SwordSkill : MonoBehaviour
{
    public GameObject swordPrefab; // Prefab của thanh kiếm
    public float radius = 5f; // Bán kính vòng xoay của thanh kiếm
    public int swordCount = 3; // Số lượng thanh kiếm
    public float rotationSpeed = 100f; // Tốc độ xoay
    public float skillDuration = 3f; // Thời gian tồn tại của kỹ năng

    private GameObject[] swords;
    private bool isSkillActive = false;

    public Image countdownImage; // Tham chiếu đến UI Image đếm ngược
    private bool isCooldown = false;
    public float CooldownSkill = 3f; // Thời gian chờ giữa các lần dùng skill
    private float timeSinceLastSkill; // Biến đếm thời gian từ lần dùng skill
    private UIController uI;

    void Start()
    {
        uI = FindObjectOfType<UIController>();

        // Khởi tạo timer
        countdownImage.fillAmount = 0;
    }

    void Update()
    {
        timeSinceLastSkill += Time.deltaTime;
        if (Input.GetKey(KeyCode.V) && timeSinceLastSkill >= CooldownSkill && isCooldown == false)
        {
            timeSinceLastSkill = 0f;
            //cd skill
            isCooldown = true;
            countdownImage.fillAmount = 1;

            ActivateSkill();
        }
        // cd skill
        if (isCooldown)
        {
            countdownImage.fillAmount -= 1 / CooldownSkill * Time.deltaTime;
            if (countdownImage.fillAmount <= 0)
            {
                countdownImage.fillAmount = 0;
                isCooldown = false;
            }
        }


        //------------
        if (isSkillActive)
        {
            RotateSwords();
        }
    }

    void ActivateSkill()
    {
        if (swords != null)
        {
            foreach (GameObject sword in swords)
            {
                Destroy(sword);
            }
        }

        swords = new GameObject[swordCount];
        for (int i = 0; i < swordCount; i++)
        {
            float angle = i * Mathf.PI * 2 / swordCount;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            swords[i] = Instantiate(swordPrefab, transform.position + position, Quaternion.identity, transform);
        }

        isSkillActive = true;
        StartCoroutine(DeactivateSkillAfterTime(skillDuration));
    }

    void RotateSwords()
    {
        for (int i = 0; i < swordCount; i++)
        {
            swords[i].transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator DeactivateSkillAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);

        foreach (GameObject sword in swords)
        {
            if (sword != null)
            {
                Destroy(sword);
            }
        }

        isSkillActive = false;
    }
}
