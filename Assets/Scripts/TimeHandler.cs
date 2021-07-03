using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timeRunning = true;

    private void OnEnable()
    {
        EventManager.onLevelFail += EventManager_onLevelFail;
    }



    private void OnDisable()
    {
        EventManager.onLevelFail -= EventManager_onLevelFail;

    }
    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                EventManager.TimerUpdated(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timeRunning = false;
                EventManager.LevelComplete(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void EventManager_onLevelFail(int value)
    {
        timeRunning = false;
    }
}
