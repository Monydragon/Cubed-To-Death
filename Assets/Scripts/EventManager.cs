using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void D_Void();
    public delegate void D_Int(int value);
    public delegate void D_Float(float value);
    public delegate void D_GameState(GameManager.GameState state);

    public static event D_Int onLevelStart;
    public static event D_Int onLevelFail;
    public static event D_Int onLevelComplete;
    public static event D_Void onGameComplete;
    public static event D_Void onCurrentLevelRestart;
    public static event D_Void onAllLevelsRestart;
    public static event D_Void onScoreChanged;
    public static event D_Void onGamePaused;
    public static event D_Float onTimerUpdated;
    public static event D_GameState onStateChanged;

    public static void LevelStart(int scene_index) { onLevelStart?.Invoke(scene_index); }
    public static void LevelFail(int scene_index) { onLevelFail?.Invoke(scene_index); }
    public static void LevelComplete(int scene_index) { onLevelComplete?.Invoke(scene_index); }
    public static void GameComplete() { onGameComplete?.Invoke(); }
    public static void RestartCurrentLevel() { onCurrentLevelRestart?.Invoke(); }
    public static void RestartAllLevels() { onAllLevelsRestart?.Invoke(); }
    public static void ScoreChanged() { onScoreChanged?.Invoke(); }
    public static void GamePause() { onGamePaused?.Invoke(); }
    public static void TimerUpdated(float timer) { onTimerUpdated?.Invoke(timer); }
    public static void GameStateChanged(GameManager.GameState state) { onStateChanged?.Invoke(state); }

}
