using UnityEngine;

public class BerserkStrategy : ISkeletonStrategy
{
    private Transform skeleton;
    private Transform player;
    private float speed;

    public BerserkStrategy(Transform skeleton, Transform player, float speed)
    {
        this.skeleton = skeleton;
        this.player = player;
        this.speed = speed;
    }

    public void Execute()
    {
        Vector3 direction = player.position - skeleton.position;
        direction.y = 0f;

        skeleton.position += direction.normalized * (speed * 2f) * Time.deltaTime;
    }
}