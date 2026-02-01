using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [Header("Cài đặt di chuyển")]
    public float moveSpeed = 5f;

    void Update()
    {
        // 1. Lấy đầu vào từ bàn phím
        float moveX = Input.GetAxisRaw("Horizontal"); // Dùng GetAxisRaw để phản hồi nhạy hơn (không có độ trễ quán tính)
        float moveY = Input.GetAxisRaw("Vertical");

        // 2. Tạo vector di chuyển
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // 3. Chuẩn hóa Vector (Normalize)
        // Điều này cực kỳ quan trọng: giúp tốc độ đi chéo không bị nhanh hơn đi thẳng
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // 4. Cập nhật vị trí
        // Time.deltaTime đảm bảo tốc độ ổn định trên mọi loại máy tính
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}