using UnityEngine;

public class SkeletonFactory : MonoBehaviour
{
    [SerializeField] private GameObject skeletonPrefab;

    public GameObject CreateSkeleton(SkeletonType type, Vector3 position, Transform player)
    {
        GameObject skeletonObject = Instantiate(skeletonPrefab, position, Quaternion.identity);

        Skeleton skeleton = skeletonObject.GetComponent<Skeleton>();
        Renderer skeletonRenderer = skeletonObject.GetComponentInChildren<Renderer>();

        float speed = 3f;
        float maxHealth = 100f;

        switch (type)
        {
            case SkeletonType.Normal:
                skeletonObject.transform.localScale = Vector3.one;
                skeletonRenderer.material.color = Color.white;
                speed = 3f;
                maxHealth = 100f;
                break;

            case SkeletonType.Berserker:
                skeletonObject.transform.localScale = Vector3.one * 1.3f;
                skeletonRenderer.material.color = Color.red;
                speed = 4.5f;
                maxHealth = 70f;
                break;

            case SkeletonType.Defensive:
                skeletonObject.transform.localScale = Vector3.one * 1.5f;
                skeletonRenderer.material.color = Color.blue;
                speed = 1.5f;
                maxHealth = 200f;
                break;
        }

        skeleton.Setup(type, player, speed, maxHealth);

        return skeletonObject;
    }
}