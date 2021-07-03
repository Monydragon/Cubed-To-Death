using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCubeController : MonoBehaviour
{
    public float despawnTimer = 3f;
    public int scoreValue = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventManager.LevelFail(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Player Hit!");
            collision.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if(GameManager.instance.gameState == GameManager.GameState.Playing)
        {
            GameManager.instance.score += scoreValue;
            EventManager.ScoreChanged();
        }
    }
}
