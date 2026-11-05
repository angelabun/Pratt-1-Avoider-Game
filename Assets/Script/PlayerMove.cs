using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 15f;

    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;  // drag GameOverText here in inspector

    private float surviveTime;
    private int score = 0;
    private bool gameIsOver;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameIsOver) return;

        // A = left, D = right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);

        surviveTime += Time.deltaTime;
        timerText.text = "Time: " + surviveTime.ToString("F1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameIsOver) return;

        // Hit cookie → game over
        if (other.CompareTag("Enemy"))
        {
            GameOverNow();
        }

        // Catch candy, add points
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("🍬 Got candy!");
            score += 1;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }

    void GameOverNow()
    {
        gameIsOver = true;
      	Time.timeScale = 0;

        // Show game‑over message with your final stats
        gameOverText.gameObject.SetActive(true); 
        gameOverText.text = $"GAME OVER \nSurvived: {surviveTime:F1} sec\nFinal Score: {score}";

        Debug.Log("🧸 Oh no! Teddy bear got bonked by a cookie! Candy party over!");
    }
}