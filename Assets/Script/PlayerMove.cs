using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 6f;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    private float surviveTime;
    private int score = 0;
    private bool gameIsOver;

    void Update()
    {
        if(gameIsOver) return;

        // A = left, D = right
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);

        // count how long you live
        surviveTime += Time.deltaTime;
        timerText.text = "Time: " + surviveTime.ToString("F1");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameIsOver) return;

        // hit cookie (enemy) → game over
        if(other.CompareTag("Enemy"))
        {
            GameOverNow();
        }

        // catch candy collectible, add score
        if(other.CompareTag("Collectible"))
        {
            Debug.Log("🍬 Got candy!");
            score = score +1;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }

    void GameOverNow()
    {
        gameIsOver = true;
        Time.timeScale = 0;
        Debug.Log("🧸 Oh no! Teddy bear got bonked by a cookie! Candy party over!");
    }
}
