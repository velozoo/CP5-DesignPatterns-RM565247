using UnityEngine;

public class ChaseStrategy : ISkeletonStrategy
{
    private Transform skeleton;
    private Transform player;
    private float speed;

    public ChaseStrategy(Transform skeleton, Transform player, float speed)
    {
        this.skeleton = skeleton;
        this.player = player;
        this.speed = speed;
    }

    public void Execute()
    {
        Vector3 direction = player.position - skeleton.position;
        direction.y = 0f;

        skeleton.position += direction.normalized * speed * Time.deltaTime;
    }
}