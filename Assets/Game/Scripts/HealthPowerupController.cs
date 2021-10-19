using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerupController : MonoBehaviour
{
    public float despawnTimer = 3f;
    public int healthValue = 1;

    void Start()
    {
        Destroy(gameObject, despawnTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit!");
            EventManager.PlayerHeal(healthValue);
            EventManager.PlayAudioSFX("HealthPickup");
            Destroy(gameObject);
        }
    }
}
