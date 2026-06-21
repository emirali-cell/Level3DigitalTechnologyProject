using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Numerics;

public class SpawnerScript : MonoBehaviour
{
    public GameObject spiderPrefab;
    public GameObject kangarooPrefab;
    public GameObject birdPrefab;
    public GameObject emuPrefab;
    public GameObject crocodilePrefab;
    public GameObject fishPrefab;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float spiderTimer = 0f;
    [SerializeField] private float kangarooTimer = 0f;
    [SerializeField] private float birdTimer = 0f;
    [SerializeField] private float emuTimer = 0f;
    [SerializeField] private float crocodileTimer = 0f;
    [SerializeField] private float fishTimer = 0f;
    private UnityEngine.Vector3 spiderSpawnPoint;
    private UnityEngine.Vector3 kangarooSpawnPoint;
    private UnityEngine.Vector3 birdSpawnPoint;
    private UnityEngine.Vector3 emuSpawnPoint;
    private UnityEngine.Vector3 crocodileSpawnPoint;
    private UnityEngine.Vector3 fishSpawnPoint;
    [SerializeField] private float waveNumber = 1f;
    [SerializeField] private double spiderSpawnTime;
    [SerializeField] private double kangarooSpawnTime;
    [SerializeField] private double birdSpawnTime;
    [SerializeField] private double emuSpawnTime;
    [SerializeField] private double crocodileSpawnTime;
    [SerializeField] private double fishSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spiderSpawnPoint = new UnityEngine.Vector3(34f, -12f, 0f);
        spiderSpawnTime = 2.22 * Math.Pow(0.9, waveNumber);

        kangarooSpawnPoint = new UnityEngine.Vector3(36f, -12f, 0);
        kangarooSpawnTime = 2;

        
        birdSpawnTime = 2;
        
        emuSpawnPoint = new UnityEngine.Vector3(30f, -12f, 0f);
        emuSpawnTime = 2;

        crocodileSpawnTime = 2;

        fishSpawnTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spiderTimer += Time.deltaTime;
        kangarooTimer += Time.deltaTime;
        birdTimer += Time.deltaTime;
        emuTimer += Time.deltaTime;
        crocodileTimer += Time.deltaTime;
        fishTimer += Time.deltaTime;
        
        
        if (spiderTimer >= spiderSpawnTime  && waveNumber == 1||
            spiderTimer >= spiderSpawnTime && waveNumber > 2)
        {
            spiderTimer = 0f;
            spiderSpawn();

        }

        if (kangarooTimer >= kangarooSpawnTime && waveNumber == 2||
            kangarooTimer >= kangarooSpawnTime && waveNumber > 2)
        {
            kangarooTimer = 0f;
            KangarooSpawn();
        }

        

        if (birdTimer >= birdSpawnTime && waveNumber >= 3)
        {
            birdTimer = 0f;
            int randomBirdY = UnityEngine.Random.Range(-7, 14);
            birdSpawnPoint = new UnityEngine.Vector3(35f, randomBirdY, 0);
            BirdSpawn();
            
        }

        if (emuTimer >= emuSpawnTime && waveNumber == 4)
        {
            emuTimer = 0f;
            EmuSpawn();
        }

        if (crocodileTimer >= crocodileSpawnTime && waveNumber >= 1)
        {
           crocodileTimer = 0f;
           int randomCrocodileX = UnityEngine.Random.Range(-25, 29);
           crocodileSpawnPoint = new UnityEngine.Vector3(randomCrocodileX, -23, 0);
           CrocodileSpawn();
        }

        if (fishTimer >= fishSpawnTime && waveNumber >= 7)
        {
            fishTimer = 0f;
            float randomFishX = UnityEngine.Random.Range(8.5f,49f);
            fishSpawnPoint = new UnityEngine.Vector3(randomFishX, 19,0);
            FishSpawn();
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

    private void BirdSpawn()
    {
        int randomInt = UnityEngine.Random.Range(0, 4);

        
        
        if (randomInt == 1)
        {
           
            Instantiate(birdPrefab, birdSpawnPoint, UnityEngine.Quaternion.identity);
        }
    }

    private void EmuSpawn()
    {
        int randomInt = UnityEngine.Random.Range(0,3);

        if (randomInt == 1)
        {
           
            Instantiate(emuPrefab, emuSpawnPoint, UnityEngine.Quaternion.identity);
        }
    }

    private void CrocodileSpawn()
    {
        int randomInt = UnityEngine.Random.Range(0, 3);
            
        if (randomInt == 1)
        {
           
         Instantiate(crocodilePrefab, crocodileSpawnPoint, UnityEngine.Quaternion.identity);
        }
    }

    private void FishSpawn()
    {
        UnityEngine.Quaternion specificRotation = UnityEngine.Quaternion.Euler(0f, 0f, 45f);
        int randomInt = UnityEngine.Random.Range(0,3);

        if (randomInt == 1)
        {
         Instantiate(fishPrefab, fishSpawnPoint, specificRotation);
        }
    }
}
