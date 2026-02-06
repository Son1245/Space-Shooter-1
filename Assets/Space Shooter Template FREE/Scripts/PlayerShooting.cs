using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Cấu hình đạn")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Thông số bắn")]
    public float shootingInterval = 0.2f;
    private float nextFireTime;

    [Header("Nâng cấp vũ khí")]
    public int weaponPower = 1;        // Cấp vũ khí hiện tại
    public int maxWeaponPower = 5;     // Cấp tối đa

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + shootingInterval;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("LỖI: Chưa gán Bullet Prefab!");
            return;
        }

        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        Quaternion spawnRot = firePoint != null ? firePoint.rotation : transform.rotation;

        // Bắn theo cấp vũ khí
        for (int i = 0; i < weaponPower; i++)
        {
            float angleOffset = (i - (weaponPower - 1) / 2f) * 10f;
            Quaternion rotation = spawnRot * Quaternion.Euler(0, 0, angleOffset);

            Instantiate(bulletPrefab, spawnPos, rotation);
        }
    }
}
