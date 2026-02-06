using UnityEngine;

public class Bonus : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            // Lấy PlayerShooting từ Player vừa va chạm
            PlayerShooting playerShooting = collision.GetComponent<PlayerShooting>();

            if (playerShooting != null)
            {
                if (playerShooting.weaponPower < playerShooting.maxWeaponPower)
                {
                    playerShooting.weaponPower++;
                    Debug.Log("Đã tăng sức mạnh vũ khí lên: " + playerShooting.weaponPower);
                }
            }

            // Hủy Bonus sau khi ăn
            Destroy(gameObject);
        }
    }
}
