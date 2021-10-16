using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCubeController : MonoBehaviour
{
    public float despawnTimer = 3f;
    public int scoreValue = 10;

    void Start()
    {
        Destroy(gameObject, despawnTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit!");
            GameManager.instance.score += scoreValue;
            EventManager.ScoreChanged();
            EventManager.PlayAudioSFX("CoinPickup");
            Destroy(gameObject);
        }
    }
}
