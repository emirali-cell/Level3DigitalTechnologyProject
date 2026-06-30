using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    public GameObject doubleJumpItem;
    public List<GameObject> itemList;

    private Vector3 itemSpawnPoint;
    private float spawnTimer = 0f;
    public float itemSpawnTime = 45f;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C) || spawnTimer >= itemSpawnTime)
        {
            int randomItem = Random.Range(0, 4);

            float randomX = Random.Range(-27f, 26);
            float randomY = Random.Range(-12, 0);
            itemSpawnPoint = new Vector3(randomX, randomY, 0);

            Instantiate(itemList[randomItem], itemSpawnPoint, Quaternion.identity);

            spawnTimer = 0f;
        }
    }
}
