using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePowerupController : MonoBehaviour
{
    public float despawnTimer = 3f;
    public float timeValueMod = 10;

    void Start()
    {
        Destroy(gameObject, despawnTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit!");
            EventManager.TimerAddValue(timeValueMod);
            EventManager.PlayAudioSFX("ClockTick");
            Destroy(gameObject);
        }
    }
}
