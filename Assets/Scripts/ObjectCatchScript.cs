using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCatchScript : MonoBehaviour
{
    [Header("Scaling")]
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;

    [Header("Score")]
    public int donutScore = 10;
    public int damageScoreLoss = 5;
    private int currentScore = 0;
    public TMP_Text scoreText;

    [Header("Lives")]
    public int maxLives = 3;
    private int currentLives;
    public TMP_Text livesText;

    [Header("Game Over")]
    public GameObject gameOverUI;
    private Animator gameOverAnimator;

    private Rigidbody2D rb;
    private SFX_Script sfx;

    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = FindFirstObjectByType<SFX_Script>();

        currentLives = maxLives;
        currentScore = 0;

        gameOverUI.SetActive(false);

        gameOverAnimator = gameOverUI.GetComponent<Animator>();

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
        else if (collision.CompareTag("Asteroid") || collision.CompareTag("Weight"))
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

        // Palaid animāciju vienreiz
        if (gameOverAnimator != null)
        {
            gameOverAnimator.Play("GameOverFadeIn", 0, 0f);
        }

        Time.timeScale = 0f;
    }

    // Izsauc šo funkciju no Restart pogas
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}