using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Khi có va chạm trigger → chết
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, 1f);
        }

        Destroy(gameObject);
    }
}
