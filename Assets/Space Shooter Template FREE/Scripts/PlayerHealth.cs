using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Die()
    {
        Debug.Log("Player died");
        base.Die();   // gọi logic nổ + huỷ
    }
}
