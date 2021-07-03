using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI liveText;
    public AudioSource music;
    public Button startButton;
    public Button restartButton;

    public Slider healthSlider;
    public int amountOfHealthToBeDead;
    private int currentHealth;

    public bool isGameActive;
    private bool isPaused;

    private PlayerController playerControllerS;
    private SpawnManager spawnManagerS;

    private float enemyDelay = 2;
    private float enemyInterval = 5;

    private float ballDelay = 5;
    private float ballInterval = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerS = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManagerS = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        music = GetComponent<AudioSource>();

        startText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        healthSlider.gameObject.SetActive(false);
        liveText.gameObject.SetActive(false);

        isGameActive = false;
        isPaused = false;
        playerControllerS.playerRb.constraints = RigidbodyConstraints.FreezePositionY;

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        healthSlider.maxValue = amountOfHealthToBeDead;
        healthSlider.value = 0;
        healthSlider.fillRect.gameObject.SetActive(false);

        startButton.onClick.AddListener(StartGame);

    }

    // Update is called once per frame
    void Update()
    {
        PausedGame();
    }

    public void AddScore(int value)
    {
        if(isGameActive == true)
        {
            score += value;
            scoreText.SetText("Score: " + score);
        }
        
    }

    public void RemoveLives(int amount)
    {
        if(isGameActive == true)
        {
            currentHealth += amount;
            healthSlider.fillRect.gameObject.SetActive(true);
            healthSlider.value = currentHealth;

            if (currentHealth >= amountOfHealthToBeDead)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        music.Stop();
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartScene);
        spawnManagerS.CancelInvoke("SpawnEnemy");
        spawnManagerS.CancelInvoke("SpawnBall");
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PausedGame()
    {
        if (isGameActive && isPaused == false && Input.GetKeyDown(KeyCode.S))
        {
            isPaused = true;
            music.Stop();
            Time.timeScale = 0;
        }
        else if(isGameActive && isPaused == true && Input.GetKeyDown(KeyCode.S))
        {
            isPaused = false;
            music.Play();
            Time.timeScale = 1;
        }
    }

    private void StartGame()
    {
        startText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        healthSlider.gameObject.SetActive(true);
        liveText.gameObject.SetActive(true);
        isGameActive = true;
        music.Play();
        playerControllerS.playerRb.constraints = ~RigidbodyConstraints.FreezePositionY;
        spawnManagerS.InvokeRepeating("SpawnEnemy", enemyDelay, enemyInterval);     
        spawnManagerS.InvokeRepeating("SpawnBall", ballDelay, ballInterval);     
    }
}
