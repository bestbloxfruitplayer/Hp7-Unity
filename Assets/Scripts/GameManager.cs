using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject GameOverUi;
    [SerializeField]public Transform ResetP;
    public bool isGameOver = true;
    public GameObject Player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(); 
        GameOverUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // temporary
        if (isGameOver == true)
        {
            GameOverUi.SetActive(true);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        GameOverUi.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        GameOverUi.SetActive(false);
        SceneManager.LoadScene("Tam");
      
    }
}
