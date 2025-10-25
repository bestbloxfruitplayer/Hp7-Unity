using UnityEngine;



public class PlayerCollision1 : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
        {
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))

        {
            GameManager.Destroy(gameObject);
        }

        

        {
            
        }


    }
}