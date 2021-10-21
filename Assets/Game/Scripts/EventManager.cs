using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void D_Void();
    public delegate void D_Int(int value);
    public delegate void D_String(string value);
    public delegate void D_Float(float value);
    public delegate void D_Bool(bool value);
    public delegate void D_GameState(GameManager.GameState state);
    public delegate void D_IntString(int value, string value2);

    public static event D_Int onLevelStart;
    public static event D_Int onLevelFail;
    public static event D_Int onLevelComplete;
    public static event D_Int onPlayerHurt;
    public static event D_Int onPlayerHeal;
    public static event D_Void onPlayerHealthChanged;
    public static event D_Void onGameComplete;
    public static event D_Void onCurrentLevelRestart;
    public static event D_Void onAllLevelsRestart;
    public static event D_Void onScoreChanged;
    public static event D_Void onGamePaused;
    public static event D_Void onGameReset;
    public static event D_Float onTimerUpdated;
    public static event D_String onAudioPlaySFX;
    public static event D_String onAudioPlayBGM;
    public static event D_GameState onStateChanged;
    public static event D_IntString onHighscoreAdd;
    public static event D_Float onTimerAddValue;

    public static void LevelStart(int scene_index) { onLevelStart?.Invoke(scene_index); }
    public static void LevelFail(int scene_index) { onLevelFail?.Invoke(scene_index); }
    public static void LevelComplete(int scene_index) { onLevelComplete?.Invoke(scene_index); }
    public static void PlayerHurt(int damage) { onPlayerHurt?.Invoke(damage); }
    public static void PlayerHeal(int amount) { onPlayerHeal?.Invoke(amount); }
    public static void PlayerHealthChanged() { onPlayerHealthChanged?.Invoke(); }
    public static void GameComplete() { onGameComplete?.Invoke(); }
    public static void RestartCurrentLevel() { onCurrentLevelRestart?.Invoke(); }
    public static void RestartAllLevels() { onAllLevelsRestart?.Invoke(); }
    public static void ScoreChanged() { onScoreChanged?.Invoke(); }
    public static void GamePause() { onGamePaused?.Invoke(); }
    public static void GameReset() { onGameReset?.Invoke(); }
    public static void TimerUpdated(float timer) { onTimerUpdated?.Invoke(timer); }
    public static void PlayAudioSFX(string name) { onAudioPlaySFX?.Invoke(name); }
    public static void PlayAudioBGM(string name) { onAudioPlayBGM?.Invoke(name); }
    public static void GameStateChanged(GameManager.GameState state) { onStateChanged?.Invoke(state); }
    public static void HighscoreAdd(string name, int score) { onHighscoreAdd?.Invoke(score, name); }
    public static void TimerAddValue(float timerVal) { onTimerAddValue?.Invoke(timerVal); }
}
