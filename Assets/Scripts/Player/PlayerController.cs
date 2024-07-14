using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 moveInput;

    private UIController uI;

    [SerializeField]
    float maxHealth;
    [NonSerialized]
    public float currentHealth;
    public HealthBar healthBar;
    public UnityEvent Ondeath;

    //public GameObject ghostEffect;
    //public float timeGhost;
    //public Coroutine dashEffectCoroutine;

    void Start()
    {
        uI = FindObjectOfType<UIController>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void UpdateHealthBar()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
}
