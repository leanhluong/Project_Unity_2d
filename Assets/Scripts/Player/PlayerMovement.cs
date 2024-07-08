using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    public GameObject weapon;  // Tham chiếu đến đối tượng vũ khí
    private SpriteRenderer playerRenderer;
    private SpriteRenderer weaponRenderer;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.y > 0)
        {
            // Player di chuyển lên trên
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        }
        else
        {
            // Player đứng yên hoặc di chuyển xuống dưới
            weaponRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }

        SkillLuot();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
        // Kiểm tra hướng di chuyển của player

    }

    private void SkillLuot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false)
        {
            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;

        }
        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;

        }
        else
        {
            _dashTime -= Time.deltaTime;
        }
    }
}
