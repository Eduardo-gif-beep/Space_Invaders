using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class SCORE_MANAGERBALL : MonoBehaviour
{
    public static SCORE_MANAGERBALL Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI lastScore;
    [SerializeField] TextMeshProUGUI timerText; 
    [SerializeField] string prefix = "Puntos: ";

    [Header("Timer Settings")]
    [SerializeField] float timeRemaining = 180f; 

    int score = 0;
    int bestscore = 0;
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
                GameObject menuCanvas = GameObject.Find("Score");
                Debug.Log("Tiempo agotado");
                timeRemaining = 0;
                timerIsRunning = false;
                timeRemaining = 180f;
                UpdateUI();
                Destroy(menuCanvas);
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

    public void AddPoints(int points)
    {
        score = score + points;
        UpdateUI();

        if (score >= 10000)
        {
            Debug.Log("Puntuación máxima alcanzada. Limpiando y volviendo al menú.");
            GameObject menuCanvas = GameObject.Find("Score");
            if (menuCanvas != null)
            {
                Destroy(menuCanvas);
            }
            timerIsRunning = false;
            timeRemaining = 180f; 
            UpdateUI2();
            SceneManager.LoadScene("Menu");
        }
    }

    public void ResetScore()
    {
        score = 0;
        timerIsRunning = true;
        UpdateUI();
    }

    public void UpdateUI2()
    {
        if (lastScore != null)
            lastScore.text = "Última puntuación: " + score.ToString();

        if (score > bestscore)
        {
            bestscore = score;
            if (bestScore != null)
                bestScore.text = "Mejor puntuación: " + bestscore.ToString();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = prefix + score.ToString();
    }
}