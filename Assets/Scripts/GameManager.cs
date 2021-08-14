using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        Menu,
        GameStart,
        Playing,
        Paused,
        GameOver,
        LevelComplete
    }

    public static GameManager instance;
    public int score;
    public GameState gameState;

    private void OnEnable()
    {
        EventManager.onLevelFail += EventManager_onLevelFail;
        EventManager.onLevelStart += EventManager_onLevelStart;
        EventManager.onLevelComplete += EventManager_onLevelComplete;
        EventManager.onStateChanged += EventManager_onStateChanged;
        EventManager.onGamePaused += EventManager_onGamePaused;
    }

    private void OnDisable()
    {
        EventManager.onLevelFail -= EventManager_onLevelFail;
        EventManager.onLevelStart -= EventManager_onLevelStart;
        EventManager.onLevelComplete -= EventManager_onLevelComplete;
        EventManager.onStateChanged -= EventManager_onStateChanged;
        EventManager.onGamePaused -= EventManager_onGamePaused;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EventManager_onLevelFail(int value)
    {
        EventManager.GameStateChanged(GameState.GameOver);
        EventManager.PlayAudioSFX("GameOver");
    }

    private void EventManager_onLevelStart(int value)
    {
        EventManager.GameStateChanged(GameState.GameStart);
    }

    private void EventManager_onLevelComplete(int value)
    {
        EventManager.GameStateChanged(GameState.LevelComplete);
        EventManager.PlayAudioSFX("LevelComplete");
    }

    private void EventManager_onStateChanged(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.Menu:
                Time.timeScale = 0;
                Debug.Log("GAME STATE: MENU");
                break;
            case GameState.GameStart:
                Debug.Log("GAME STATE: GAME START");
                EventManager.GameStateChanged(GameState.Playing);
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                Debug.Log("GAME STATE: PLAYING");
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                Debug.Log("GAME STATE: PAUSED");
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                Debug.Log("GAME STATE: GAME OVER");
                break;
            case GameState.LevelComplete:
                Time.timeScale = 0;
                Debug.Log("GAME STATE: LEVEL COMPLETE");
                break;
        }
    }
    private void EventManager_onGamePaused()
    {
        gameState = GameState.Paused;
        EventManager.GameStateChanged(GameState.Paused);
    }
}
