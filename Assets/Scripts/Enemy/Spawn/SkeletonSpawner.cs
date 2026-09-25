using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [SerializeField] private SkeletonFactory factory;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnSkeleton), 0f, spawnInterval);
    }

    private void SpawnSkeleton()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        SkeletonType randomType = (SkeletonType)Random.Range(0, 3);

        factory.CreateSkeleton(randomType, spawnPoints[randomIndex].position, player);
    }
}