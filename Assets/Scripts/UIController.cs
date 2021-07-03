using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalscoreText;
    public TMP_Text winfinalscoreText;
    public TMP_Text timeText;
    public GameObject gameoverPanel;
    public GameObject levelCompletePanel;
    public GameObject pauseMenuPanel;

    private void OnEnable()
    {
        EventManager.onLevelFail += EventManager_onLevelFail;
        EventManager.onTimerUpdated += EventManager_onTimerUpdated;
        EventManager.onLevelComplete += EventManager_onLevelComplete;
        EventManager.onScoreChanged += EventManager_onScoreChanged;
        EventManager.onGamePaused += EventManager_onGamePaused;
    }



    private void OnDisable()
    {
        EventManager.onLevelFail -= EventManager_onLevelFail;
        EventManager.onTimerUpdated -= EventManager_onTimerUpdated;
        EventManager.onLevelComplete -= EventManager_onLevelComplete;
        EventManager.onScoreChanged -= EventManager_onScoreChanged;
        EventManager.onGamePaused -= EventManager_onGamePaused;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            EventManager.GameStateChanged(GameManager.GameState.Menu);
        }
        if(scoreText != null)
        {
            scoreText.text = $"Score: {GameManager.instance.score}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = $"Score: {GameManager.instance.score}";
        //finalscoreText.text = $"Final Score: {GameManager.instance.finalScore}";
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        GameManager.instance.score = 0;
        EventManager.ScoreChanged();
        EventManager.LevelStart(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        EventManager.LevelStart(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        EventManager.GameStateChanged(GameManager.GameState.Playing);
    }

    public void QuitGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void EventManager_onLevelFail(int value)
    {
        GameOver();
    }

    private void EventManager_onTimerUpdated(float value)
    {
        var time = value += 1;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = $"Time Remaining: {minutes:00}:{seconds:00}";
    }

    private void EventManager_onLevelComplete(int value)
    {
        levelCompletePanel.SetActive(true);
        winfinalscoreText.text = $"Final Score: {GameManager.instance.score}";
    }
    private void EventManager_onScoreChanged()
    {
        if(scoreText != null)
        {
            scoreText.text = $"Score: {GameManager.instance.score}";
        }
        if(finalscoreText != null)
        {
            finalscoreText.text = $"Final Score: {GameManager.instance.score}";
        }
        if(winfinalscoreText != null)
        {
            winfinalscoreText.text = $"Final Score: {GameManager.instance.score}";
        }
    }
    private void EventManager_onGamePaused()
    {
        pauseMenuPanel.SetActive(true);
    }
}
