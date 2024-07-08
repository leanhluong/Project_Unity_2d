using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private bool isDestroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDestroy)
        {
            isDestroy = true;
            collision.GetComponent<PlayerController>().takeDame(20);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
