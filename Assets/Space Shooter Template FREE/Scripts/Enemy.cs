using UnityEngine;

/// <summary>
/// Script quản lý máu và hành vi của Kẻ địch (Enemy).
/// </summary>
public class Enemy : MonoBehaviour 
{
    #region FIELDS
    [Header("Thông số máu")]
    [Tooltip("Số lượng máu của kẻ địch")]
    public int health = 1;

    [Header("Hiệu ứng & Đạn")]
    [Tooltip("Prefab đạn của kẻ địch")]
    public GameObject projectilePrefab;
    [Tooltip("Hiệu ứng khi bị tiêu diệt")]
    public GameObject destructionVFX;
    [Tooltip("Hiệu ứng khi bị trúng đạn")]
    public GameObject hitEffect;
    
    [HideInInspector] public int shotChance; 
    [HideInInspector] public float shotTimeMin, shotTimeMax; 
    #endregion

    private void Start()
    {
        // Lập lịch bắn đạn trong khoảng thời gian ngẫu nhiên
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    void ActivateShooting() 
    {
        // Kiểm tra tỉ lệ bắn
        if (Random.value < (float)shotChance / 100f) 
        {                        
            if (projectilePrefab != null)
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);             
        }
    }

    public void GetDamage(int damage) 
    {
        health -= damage;
        
        if (health <= 0)
        {
            Destruction();
        }
        else if (hitEffect != null)
        {
            // Tạo hiệu ứng trúng đạn và làm nó thành con của Enemy để di chuyển theo Enemy
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Sử dụng CompareTag để tối ưu hiệu suất hơn so với == tag
        if (collision.CompareTag("Player"))
        {
            if (Player.instance != null)
            {
                // Lấy component Projectile một lần để kiểm tra damage
                // Lưu ý: Nên cache damage này nếu dùng thường xuyên
                var projectileScript = projectilePrefab?.GetComponent<Projectile>();
                int damageToDeal = (projectileScript != null) ? projectileScript.damage : 1;
                
                Player.instance.GetDamage(damageToDeal);
            }
            
            // Tùy chọn: Enemy có thể chết luôn khi đâm vào Player
            // Destruction(); 
        }
    }

    void Destruction()                           
    {        
        if (destructionVFX != null)
            Instantiate(destructionVFX, transform.position, Quaternion.identity); 

        Destroy(gameObject);
    }
}