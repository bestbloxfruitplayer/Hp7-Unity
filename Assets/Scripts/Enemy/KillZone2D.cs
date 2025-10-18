using UnityEngine;

public class KillZone2D : MonoBehaviour
{
    [SerializeField] private GameObject enemy; // Kéo Enemy vào đây
    [SerializeField] private float bounceForce = 20f;   // Độ bật lên (tăng gấp đôi)
    [SerializeField] private float forwardForce = 15f;  // Độ đẩy về phía trước (mạnh hơn)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Xác định hướng Player đang quay (dựa vào scale X)
                float direction = Mathf.Sign(other.transform.localScale.x);

                // Hướng bật = lên + hướng Player đang quay mặt
                Vector2 bounceDirection = (Vector2.up + Vector2.right * direction).normalized;

                rb.linearVelocity = Vector2.zero; // Reset vận tốc cũ
                rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
                rb.AddForce(Vector2.right * direction * forwardForce, ForceMode2D.Impulse);
            }

            // Phá Enemy nếu có
            if (enemy != null)
            {
                Destroy(enemy);
            }

            // Phá Kill object
            Destroy(gameObject);

            Debug.Log("💨 Skibidididi! Bật cực mạnh và phá hủy Enemy + Kill!");
        }
    }
}
