using UnityEngine;

public class DefensiveStrategy : ISkeletonStrategy
{
    private Transform skeleton;
    private Transform player;
    private float speed;
    private float stoppingDistance;

    public DefensiveStrategy(
        Transform skeleton,
        Transform player,
        float speed,
        float stoppingDistance)
    {
        this.skeleton = skeleton;
        this.player = player;
        this.speed = speed;
        this.stoppingDistance = stoppingDistance;
    }

    public void Execute()
    {
        Vector3 direction = player.position - skeleton.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
            float movement = speed * Time.deltaTime;

            if (movement > distance - stoppingDistance)
            {
                movement = distance - stoppingDistance;
            }

            skeleton.position += direction.normalized * movement;
        }
    }
}