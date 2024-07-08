using UnityEngine;

public class EnemyActiveController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private void Awake()
    {
        target.SetActive(false);
    }

    private void Update()
    {
        if (target != null)
        {
            gameObject.transform.position = target.transform.position;
        }
    }

    private void OnBecameInvisible()
    {
        if(target != null) target.SetActive(false);
    }

    private void OnBecameVisible()
    {
       if(target != null) target.SetActive(true);
    }
}
