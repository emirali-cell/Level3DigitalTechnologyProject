using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;

public class SpawnerScript : MonoBehaviour
{
    public GameObject spiderPrefab;
    public GameObject kangarooPrefab;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float spiderTimer = 0f;
    [SerializeField] private float kangarooTimer = 0f;
    private UnityEngine.Vector3 spiderSpawnPoint;
    private UnityEngine.Vector3 kangarooSpawnPoint;
    [SerializeField] private float waveNumber = 1f;
    [SerializeField] private double spiderSpawnTime;
    [SerializeField] private double kangarooSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spiderSpawnPoint = new UnityEngine.Vector3(34f, -12f, 0f);
        spiderSpawnTime = 2.22 * Math.Pow(0.9, waveNumber);

        kangarooSpawnPoint = new UnityEngine.Vector3(30f, -12f, 0);
        kangarooSpawnTime = 2;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spiderTimer += Time.deltaTime;
        kangarooTimer += Time.deltaTime;
        
        if (spiderTimer >= spiderSpawnTime  && waveNumber == 2||
            spiderTimer >= spiderSpawnTime && waveNumber > 2)
        {
            spiderTimer = 0f;
            spiderSpawn();

        }

        if (kangarooTimer >= kangarooSpawnTime && waveNumber == 1||
            kangarooTimer >= kangarooSpawnTime && waveNumber > 2)
        {
            kangarooTimer = 0f;
            KangarooSpawn();
        }

        if (timer >= 45f)
        {
            waveNumber += 1f;
            timer = 0f;
            Debug.Log($"Wave {waveNumber}");
        }
    }

    private void spiderSpawn()
    {
        
        int randomInt = UnityEngine.Random.Range(0, 2);
        
        if (randomInt == 1)
        {
            
            Instantiate(spiderPrefab, spiderSpawnPoint, UnityEngine.Quaternion.identity);
        }
    }

    private void KangarooSpawn()
    {
        int randomInt = UnityEngine.Random.Range(0, 3);
        
        if (randomInt == 1)
        {
           
            Instantiate(kangarooPrefab, kangarooSpawnPoint, UnityEngine.Quaternion.identity);
        }
    }
}
