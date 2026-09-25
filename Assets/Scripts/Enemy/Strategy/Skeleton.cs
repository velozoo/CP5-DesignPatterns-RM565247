using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Transform player;
    private float speed;
    private float maxHealth;
    private float currentHealth;
    [SerializeField] private float collisionDamage = 20f;

    private ISkeletonStrategy strategy;

    public void Setup(SkeletonType type, Transform player, float speed, float maxHealth)
    {
        this.player = player;
        this.speed = speed;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;

        switch (type)
        {
            case SkeletonType.Normal:
                SetStrategy(new ChaseStrategy(transform, player, speed));
                break;

            case SkeletonType.Berserker:
                SetStrategy(new BerserkStrategy(transform, player, speed));
                break;

            case SkeletonType.Defensive:
                SetStrategy(new DefensiveStrategy(transform, player, speed, 3f));
                break;
        }
    }

    private void Update()
    {
        if (strategy != null)
        {
            strategy.Execute();
        }

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        ScoreManager.Instance.AddScore(100);
        Destroy(gameObject);
    }

    public void SetStrategy(ISkeletonStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(collisionDamage);
        }
    }
}