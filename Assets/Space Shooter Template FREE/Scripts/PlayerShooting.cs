using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Cấu hình đạn")]
    public GameObject bulletPrefab; // Đổi thành số ít cho đúng ngữ pháp
    public Transform firePoint;     // Điểm nòng súng (nếu bạn muốn đạn bay ra từ nòng súng thay vì giữa người)
    
    [Header("Thông số bắn")]
    public float shootingInterval = 0.2f; 
    private float nextFireTime; // Dùng cách này sẽ gọn hơn lastBulletTime

    void Update()
    {
        // Sử dụng GetButton thay vì GetMouseButton giúp bạn dễ dàng đổi phím trong Input Manager sau này
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            ShootBullet();
            // Thiết lập thời điểm tiếp theo được phép bắn
            nextFireTime = Time.time + shootingInterval;
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab != null)
        {
            // Nếu có điểm nòng súng (firePoint) thì bắn từ đó, không thì bắn từ vị trí Player
            Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;
            Quaternion spawnRotation = firePoint != null ? firePoint.rotation : transform.rotation;

            Instantiate(bulletPrefab, spawnPosition, spawnRotation);
        }
        else
        {
            Debug.LogError("LỖI: Bạn chưa kéo Bullet Prefab vào ô trống trong Inspector!");
        }
    }
}