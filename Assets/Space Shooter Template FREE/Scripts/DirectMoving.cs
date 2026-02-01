using UnityEngine;

public class DirectMoving : MonoBehaviour 
{
    [Tooltip("Tốc độ di chuyển theo trục Y (Số dương là đi lên, số âm là đi xuống)")]
    public float speed = 5f;

    void Update()
    {
        // Di chuyển đối tượng dựa trên Vector3.up (0, 1, 0)
        // Space.Self đảm bảo vật thể di chuyển theo hướng "lên trên" của chính nó (Local Space)
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self); 
    }
}