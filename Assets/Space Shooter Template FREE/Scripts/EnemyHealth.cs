using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        Debug.Log("Enemy died");
        base.Die();   // gọi logic nổ + huỷ
    }
}

