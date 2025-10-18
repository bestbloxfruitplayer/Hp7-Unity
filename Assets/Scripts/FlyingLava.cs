using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingLava : MonoBehaviour
{

    public Transform StartP;
    public Transform EndP;
    private Vector3 Land;


    private void falling()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(StartP.position, Land, 5 * Time.deltaTime);
            if (Vector3.Distance(transform.position, Land) < 0.1f)
            {
             transform.position = StartP.position;
            }
        }


    }


    public Transform Reset;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = Reset.position;
        }
    }


    void Start()
    {
        Land = EndP.position;
    }

    // Update is called once per frame
    void Update()
    {
        falling();
    }
}
