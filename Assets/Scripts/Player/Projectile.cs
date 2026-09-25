using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float damage = 25f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            return;

        Skeleton skeleton = collision.gameObject.GetComponentInParent<Skeleton>();

        if (skeleton != null)
        {
            skeleton.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}