using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private float shootDistance = 100f;
    [SerializeField] private float projectileSpeed = 30f;
    [SerializeField] private LayerMask hitLayers;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Cria um raio saindo do centro da câmera
        Ray ray = playerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        Vector3 targetPoint;

        // Descobre onde o player está olhando
        if (Physics.Raycast(ray, out RaycastHit hit, shootDistance, hitLayers))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * shootDistance;
        }

        // Calcula a direção da arma até o ponto que o player está olhando
        Vector3 shootDirection =
            (targetPoint - weaponPoint.position).normalized;

        // Cria o projétil na arma
        GameObject projectile = Instantiate(
            projectilePrefab,
            weaponPoint.position,
            Quaternion.LookRotation(shootDirection)
        );

        // Dá velocidade ao projétil
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        projectileRb.linearVelocity = shootDirection * projectileSpeed;
    }
}