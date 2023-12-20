using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameController controller;

    void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject, 1f); // Xóa vật thể này khỏi trò chơi
            controller.UpdateScore(1);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            controller.ShowGameOverPanel();
        }
    }
}
