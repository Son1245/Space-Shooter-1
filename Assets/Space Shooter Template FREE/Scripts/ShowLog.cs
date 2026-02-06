using UnityEngine;

public class ShowLog : MonoBehaviour
{
    [Header("Cấu hình Log")]
    [SerializeField] private bool showDebugLog = true;
    [SerializeField] private float logInterval = 1.0f;

    private float timer;

    private void Start()
    {
        Debug.Log("==> Hệ thống ShowLog đã khởi động thành công!");
    }

    private void Update()
    {
        if (!showDebugLog) return;

        timer += Time.deltaTime;

        if (timer >= logInterval)
        {
            Debug.Log($"[ShowLog]: Hệ thống đang chạy ổn định lúc {Time.time:F2}s");
            timer = 0f;
        }
    }
}
