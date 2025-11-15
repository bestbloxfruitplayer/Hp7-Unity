using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;
 
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;

        if (movingRight)
        {
            // Move in world space so flipping scale doesn't change direction
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);

            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
