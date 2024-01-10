using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MathGameController : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;
    public Button correctButton;
    public Button wrongButton;

    private int score = 0;
    private int highScore = 0;
    private int correctAnswer;
    private int fakeAnswer;
    private bool isGameOver = false;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Điểm cao nhất: " + highScore.ToString();
        GenerateQuestion();
        correctButton.onClick.AddListener(() => OnAnswer(true));
        wrongButton.onClick.AddListener(() => OnAnswer(false));
    }

    void GenerateQuestion()
    {
        if (isGameOver) return;

        int a = Random.Range(1, 6);
        int b = Random.Range(1, 6);
        bool isAddition = Random.Range(0, 2) == 0;

        if (isAddition)
        {
            correctAnswer = a + b;
            fakeAnswer = Random.Range(-10, 10);
            questionText.text = $"{a} + {b} = {fakeAnswer}";
            correctButton.GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer.ToString();
            wrongButton.GetComponentInChildren<TextMeshProUGUI>().text = fakeAnswer.ToString();
        }
        else
        {
            correctAnswer = a - b;
            fakeAnswer = Random.Range(-10, 10);
            questionText.text = $"{a} - {b} = {fakeAnswer}";
            correctButton.GetComponentInChildren<TextMeshProUGUI>().text = correctAnswer.ToString();
            wrongButton.GetComponentInChildren<TextMeshProUGUI>().text = fakeAnswer.ToString();
        }
    }

    public void OnAnswer(bool isCorrect)
    {
        bool isPlayerCorrect = (fakeAnswer == correctAnswer);

        if (isCorrect == isPlayerCorrect)
        {
            score++;
            scoreText.text = "Điểm: " + score.ToString();
            GenerateQuestion();
        }
        else
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            scoreText.text = "Điểm: " + score.ToString();
            highScoreText.text = "Điểm cao nhất: " + highScore.ToString();

            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
            }
        }
    }

    public void RestartGame()
    {
        score = 0;
        isGameOver = false;
        gameOverPanel.SetActive(false);
        scoreText.text = "Điểm: " + score.ToString();
        highScoreText.text = "Điểm cao nhất: " + highScore.ToString();
        GenerateQuestion();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
