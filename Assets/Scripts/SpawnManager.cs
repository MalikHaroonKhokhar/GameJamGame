using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    private float currentTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoints");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > spawnTimer)
        {
            int index = Random.Range(0, spawnPoints.Length);

            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[index].transform.position, Quaternion.identity);

            currentTimer = 0f;
        }
        else
        {
            currentTimer += Time.deltaTime;
        }
        
    }
}
