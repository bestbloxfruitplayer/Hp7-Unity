using UnityEngine;

public class CloudMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1f;        // tốc độ mây
    [SerializeField] private float distance = 3f;     // khoảng cách di chuyển qua lại

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float leftLimit = startPos.x - distance;
        float rightLimit = startPos.x + distance;

        // di chuyển mây
        if (movingRight)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;

        // đổi hướng
        if (transform.position.x >= rightLimit)
            movingRight = false;

        if (transform.position.x <= leftLimit)
            movingRight = true;
    }
}
