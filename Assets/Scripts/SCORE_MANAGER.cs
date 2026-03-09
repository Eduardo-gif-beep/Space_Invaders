using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SCORE_MANAGER : MonoBehaviour
{
    public static SCORE_MANAGER Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI timerText; 

    [Header("Settings")]
    [SerializeField] string prefix = "Points: ";
    [SerializeField] float timeRemaining = 180f;

    int score = 0;
    int deathsCounter = 0;
    int level = 1;
    bool timerIsRunning = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        UpdateUI();

        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("¡Tiempo agotado!");
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (timerText != null)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateHealth(int health)
    {
        if (healthText != null)
            healthText.text = "Health: " + health.ToString();
    }

    public void AddPoints(int points)
    {
        score = score + points;
        deathsCounter = deathsCounter + 1;
        UpdateUI();

        if (deathsCounter == 64)
        {
            nextLevel();
        }
    }

    public void ResetScore()
    {
        score = 0;
        deathsCounter = 0;
        level = 1;
        timeRemaining = 180f; 
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = prefix + score.ToString();
    }

    void nextLevel()
    {
        level = level + 1;
        deathsCounter = 0;

        if (level <= 4)
        {
            SceneManager.LoadScene("Space_Invaders " + level);
        }
        else
        {
            Debug.Log("¡Felicidades, terminaste todos los niveles!");
            timerIsRunning = false; 
        }
    }
}