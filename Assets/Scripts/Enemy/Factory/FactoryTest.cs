using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    [SerializeField] private SkeletonFactory factory;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        factory.CreateSkeleton(SkeletonType.Normal, spawnPoints[0].position, player);
        factory.CreateSkeleton(SkeletonType.Berserker, spawnPoints[1].position, player);
        factory.CreateSkeleton(SkeletonType.Defensive, spawnPoints[2].position, player);
    }
}