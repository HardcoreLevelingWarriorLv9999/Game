
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;// Assign this in the inspector
    private int score;
    public GameObject gameOverPanel;
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        // Tạm dừng game
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Load lại màn chơi hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Tiếp tục game
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        // Thoát game
        Application.Quit();
    }

}



