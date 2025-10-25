using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Khi Player chạm vào key -> đổi sang Tam
            SceneManager.LoadScene("Tam");
        }
    }
}
