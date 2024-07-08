using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float timeDie = 0.5f;

    private void Start() => Destroy(gameObject, timeDie);
}
