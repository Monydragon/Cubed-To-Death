using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCubeController : MonoBehaviour
{
    public float despawnTimer = 3f;
    public int scoreValue = 5;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedDestroy());
        //Destroy(gameObject, despawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventManager.PlayerHurt(damage);
            //EventManager.LevelFail(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Player Hit!");
            //collision.gameObject.SetActive(false);
            EventManager.PlayAudioSFX("CubeHit");
            Destroy(gameObject);

        }
    }

    public IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(despawnTimer);

        if (GameManager.instance.gameState == GameManager.GameState.Playing)
        {
            GameManager.instance.score += scoreValue;
            EventManager.ScoreChanged();
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopCoroutine(TimedDestroy());
    }
}
