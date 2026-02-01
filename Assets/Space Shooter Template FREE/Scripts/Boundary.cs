using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Boundary : MonoBehaviour 
{
    private BoxCollider2D boundaryCollider;

    private void Start()
    {
        boundaryCollider = GetComponent<BoxCollider2D>();
        boundaryCollider.isTrigger = true; // Đảm bảo collider là Trigger
        ResizeCollider();
    }

    void ResizeCollider() 
    {         
        // Tính toán kích thước dựa trên Camera Viewport
        Vector2 viewportSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;
        boundaryCollider.size = viewportSize * 1.5f;
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {         
        // Kiểm tra tag và xóa đối tượng khi ra khỏi biên
        if (collision.CompareTag("Projectile") || collision.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
        }
    }
}