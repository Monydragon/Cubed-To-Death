using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public int spawnAmount = 5;
    public List<GameObject> spawnPrefabs;
    public bool constantSpawn = true;
    public float spawnTime = 2.5f;
    private List<Transform> usedSpawnPoints = new List<Transform>();

    private void OnEnable()
    {
        EventManager.onLevelFail += EventManager_onLevelFail;
        EventManager.onLevelStart += EventManager_onLevelStart;
        EventManager.onLevelComplete += EventManager_onLevelComplete;
    }



    private void OnDisable()
    {
        EventManager.onLevelFail -= EventManager_onLevelFail;
        EventManager.onLevelStart -= EventManager_onLevelStart;
        EventManager.onLevelComplete -= EventManager_onLevelComplete;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnOnTimer(spawnTime));
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnOnTimer(float spawnTime)
    {
        while (constantSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }

    }

    public void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
        RANDSPAWN:
            var randSpawn = Random.Range(0, spawnPoints.Count);
            if (usedSpawnPoints.Contains(spawnPoints[randSpawn]))
            {
                if (usedSpawnPoints.Count >= spawnPoints.Count)
                {
                    return;
                }
                else
                {
                    goto RANDSPAWN;
                }
            }
            var randomPrefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Count)];
            Instantiate(randomPrefab, spawnPoints[randSpawn]);
            usedSpawnPoints.Add(spawnPoints[randSpawn]);
        }
        usedSpawnPoints.Clear();
    }

    private void EventManager_onLevelFail(int value)
    {
        constantSpawn = false;
    }

    private void EventManager_onLevelStart(int value)
    {
        constantSpawn = true;
    }
    private void EventManager_onLevelComplete(int value)
    {
        constantSpawn = false;
    }
}
