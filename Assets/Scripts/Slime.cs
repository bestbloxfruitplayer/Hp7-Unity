using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool InRage = false;
    public GameObject Player;
    private Vector3 target;
    private Animator animator;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private float endtime;
    private bool H;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRage = true;
            animator.SetBool("Touched", true);
        }
        else
        {
            InRage = false;
        }
    }
    void Start()
    {
        target = transform.position;
        animator = GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
        InRage = false;
    }

    void Swing()
    {
        if (InRage == true && Input.GetMouseButtonDown(0))
        {
            
            animator.SetBool("Touched", true);
            Player.transform.position = Vector3.MoveTowards(transform.position, target, 5f * Time.deltaTime);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 9);
            rb.gravityScale = 1;
            endtime = Time.time + 3f;

        }
        else
        {
            animator.SetBool("Touched", false);
        }

    }

}