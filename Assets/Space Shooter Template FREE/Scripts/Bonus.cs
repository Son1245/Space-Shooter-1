using UnityEngine;

public class Bonus : MonoBehaviour 
{
    // Khi va chạm với vật thể khác (dạng Trigger 2D)
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Kiểm tra xem vật thể va chạm có Tag là "Player" không
        if (collision.CompareTag("Player")) 
        {
            // Kiểm tra xem Instance có tồn tại không trước khi truy cập
            if (PlayerShooting.instance != null)
            {
                if (PlayerShooting.instance.weaponPower < PlayerShooting.instance.maxWeaponPower)
                {
                    PlayerShooting.instance.weaponPower++;
                    Debug.Log("Đã tăng sức mạnh vũ khí lên: " + PlayerShooting.instance.weaponPower);
                }
            }
            
            // Hủy vật phẩm Bonus sau khi ăn
            Destroy(gameObject);
        }
    }
}