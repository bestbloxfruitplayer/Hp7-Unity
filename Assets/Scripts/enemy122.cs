using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;
    private SpriteRenderer spriteRenderer;

    [Header("Bounce force when player stomps")]
    public float bounceForce = 8f;

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float left = startPos.x - moveDistance;
        float right = startPos.x + moveDistance;

        // Move
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

        if (transform.position.x >= right) movingRight = false;
        if (transform.position.x <= left) movingRight = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        // Check if player is above the necromancer
        bool playerIsAbove = rb.linearVelocity.y < 0 && collision.transform.position.y > transform.position.y + 0.3f;

        if (playerIsAbove)
        {
            // Bounce player
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

            // Kill enemy
            Destroy(gameObject);
        }
        else
        {
            // Kill player
            Destroy(collision.gameObject);
        }
    }
}
        