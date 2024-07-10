using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    //public GameObject weapon;  // Tham chiếu đến đối tượng vũ khí
    //private SpriteRenderer playerRenderer;
    //private SpriteRenderer weaponRenderer;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;


    public Image countdownImage; // Tham chiếu đến UI Image đếm ngược
    private bool isCooldown = false;
    public float CooldownSkill = 2f; // Thời gian chờ giữa các lần dùng skill
    private float timeSinceLastSkill; // Biến đếm thời gian từ lần dùng skill
    private UIController uI;

    public GameObject ghostEffect;
    public float timeGhost = 0.04f;
    private Coroutine dashEffectCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        //playerRenderer = GetComponent<SpriteRenderer>();
        //weaponRenderer = weapon.GetComponent<SpriteRenderer>();
        uI = FindObjectOfType<UIController>();

        // Khởi tạo timer
        countdownImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //if (movement.y > 0)
        //{
        //    // Player di chuyển lên trên
        //    weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        //}
        //else
        //{
        //    // Player đứng yên hoặc di chuyển xuống dưới
        //    weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        //}
        //SkillLuot();

        //dem cd
        timeSinceLastSkill += Time.deltaTime;
        CdSkill();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
        // Kiểm tra hướng di chuyển của player

    }


    private void CdSkill()
    {
        if (Input.GetKey(KeyCode.Space) && timeSinceLastSkill >= CooldownSkill && isCooldown == false && _dashTime <= 0 && isDashing == false)
        {
            timeSinceLastSkill = 0f;
            //cd skill
            isCooldown = true;
            countdownImage.fillAmount = 1;


            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;
            StopDashEffect();
        }
        else
        {
            _dashTime -= Time.deltaTime;
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
    }


    void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }

    void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }

    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            ghost.GetComponent<SpriteRenderer>().sprite= currentSprite;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(timeGhost);
        }
    }
}
