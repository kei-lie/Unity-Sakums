using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public TMP_Text livesText;          // Optional UI Text
    public GameObject gameOverUI;   // Optional Game Over screen

    void Start()
    {
        currentLives = maxLives;
        UpdateUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") ||
            collision.gameObject.CompareTag("Weight"))
        {
            TakeDamage(1);

            // Optional: destroy the bad object on impact
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid") ||
            other.gameObject.CompareTag("Weight"))
        {
            TakeDamage(1);

            // Optional: destroy the bad object on impact
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentLives -= damage;
        UpdateUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Disable player movement (optional)
        // GetComponent<PlayerMovement>().enabled = false;

        Time.timeScale = 0f; // Pause game
    }
}