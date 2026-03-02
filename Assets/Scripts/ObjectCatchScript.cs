using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCatchScript : MonoBehaviour
{
    [Header("Scaling")]
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;

    [Header("Score")]
    private int donutScore = 10;
    private int specialScore = 15;
    private int damageScoreLoss = 5;
    private int currentScore = 0;
    public TMP_Text scoreText;

    [Header("Lives")]
    public int maxLives = 3;
    private int currentLives;
    public TMP_Text livesText;

    [Header("Game Over")]
    public GameObject gameOverUI;

    private Rigidbody2D rb;
    private SFX_Script sfx;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f; // <-- IMPORTANT FIX

        rb = GetComponent<Rigidbody2D>();
        sfx = FindFirstObjectByType<SFX_Script>();

        currentLives = maxLives;
        currentScore = 0;

        gameOverUI.SetActive(false);

        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameOver) return;

        if (collision.transform.IsChildOf(transform))
            return;

        if (collision.CompareTag("Donut"))
        {
            sfx.PlaySFX(4);



            currentScore += donutScore;
            UpdateUI();

            Destroy(collision.gameObject);

            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;
        }
        else if (collision.CompareTag("Green"))
        {
            sfx.PlaySFX(4);

            currentScore += specialScore;
            UpdateUI();

            Destroy(collision.gameObject);

            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;
        }
        else if (collision.CompareTag("Asteroid"))
        {
            TakeDamage(1);

            currentScore -= damageScoreLoss;
            if (currentScore < 0)
                currentScore = 0;

            UpdateUI();

            Destroy(collision.gameObject);
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

        scoreText.text = "TEST " + Time.frameCount;

        if (livesText != null)
            livesText.text = "Lives: " + currentLives;

        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over!");

        gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    // Izsauc šo funkciju no Restart pogas
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}