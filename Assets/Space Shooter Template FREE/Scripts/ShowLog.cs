using UnityEngine;

public class ShowLog : MonoBehaviour
{
    [Header("Cấu hình Log")]
    [SerializeField] private bool showDebugLog = true; // Bật/Tắt log nhanh
    [SerializeField] private float logInterval = 1.0f; // Hiện log sau mỗi X giây

    private float timer = 0f;

    void Start()
    {
        Debug.Log("==> Hệ thống ShowLog đã khởi động thành công!");
    }

    void Update()
    {
        if (!showDebugLog) return;

        // Đếm ngược thời gian để không làm tràn Console
        timer += Time.deltaTime;
        if (timer >= logInterval)
        {
            Debug.Log($"[ShowLog]: Hệ thống đang chạy ổn định lúc {Time.time:F2}s");
            timer = 0f; // Reset bộ đếm
        }
    }
}