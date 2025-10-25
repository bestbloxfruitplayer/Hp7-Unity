using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes

public class PlayerSceneSwitch : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Sea3"; // name of the scene to go to

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Key collected! Switching scene to " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
