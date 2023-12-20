using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Snake : MonoBehaviour
{
    public GameObject joystick; // Add this line at the top of your Snake script

    public float moveSpeed;
    private Rigidbody2D rb2D;
    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(moveSpeed, 0);

        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);
    }

    // Update is called once per frame
    // Update is called once per frame
// Update is called once per frame
void Update()
{
    // Get the MovementJoystick component from the joystick game object
    MovementJoystick movementJoystick = joystick.GetComponent<MovementJoystick>();

    // Use the joystick vector to determine the direction
    if (Mathf.Abs(movementJoystick.joystickVec.x) > Mathf.Abs(movementJoystick.joystickVec.y))
    {
        if (movementJoystick.joystickVec.x > 0)
        {
            rb2D.velocity = new Vector2(moveSpeed, 0);
        }
        else if (movementJoystick.joystickVec.x < 0)
        {
            rb2D.velocity = new Vector2(-moveSpeed, 0);
        }
    }
    else
    {
        if (movementJoystick.joystickVec.y > 0)
        {
            rb2D.velocity = new Vector2(0, moveSpeed);
        }
        else if (movementJoystick.joystickVec.y < 0)
        {
            rb2D.velocity = new Vector2(0, -moveSpeed);
        }
    }
}


    private void FixedUpdate()
    {
        for (int i = _snakeSpawn.Count - 1; i > 0; i--)
        {
            _snakeSpawn[i].position = _snakeSpawn[i - 1].position;
        }
    }
    private void Grow()
    {
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;
        _snakeSpawn.Add(snakeSpawn);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
