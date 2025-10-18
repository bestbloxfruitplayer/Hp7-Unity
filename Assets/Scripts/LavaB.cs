using UnityEngine;

public class LavaB : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform Reset;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = Reset.position;
        }
    }


    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    private Vector3 target;

    private void falling()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            transform.position = pointA.position;
        }
    }
    void Start()
    {
        target = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        falling();   
    }
}
