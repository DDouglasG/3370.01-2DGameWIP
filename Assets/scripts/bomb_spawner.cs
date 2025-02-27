using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_spawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public int maxBombs = 5; // Maximum bombs allowed onscreen
    private List<GameObject> bombs = new List<GameObject>(); // Track spawned bombs
    public float spawnHeight = 5f;
    public float spawnInterval = 1.5f; // Time between spawns
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        
        // Spawn bombs only at intervals
        if (timer >= spawnInterval)
        {
            spawObject();
            timer = 0f;
        }

        // Remove any null objects from the list
        bombs.RemoveAll(item => item == null);
    }

    void spawObject()
    {
        if (bombs.Count < maxBombs)
        {
            float randomX = Random.Range(-8f, 8f); // Adjust based on screen width
            Vector3 spawnPosition = new Vector3(randomX, Camera.main.transform.position.y + spawnHeight, 0); // Spawns above the screen

            GameObject bomb = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
            bomb.GetComponent<Rigidbody2D>().gravityScale = 1;
            bombs.Add(bomb); // Add to tracking list

            // Assign a script to handle destruction
            BombDestroy bombDestroyScript = bomb.AddComponent<BombDestroy>();
            bombDestroyScript.spawner = this;
        }
    }

    // Remove bomb from the list when destroyed
    public void RemoveBomb(GameObject bomb)
    {
        bombs.Remove(bomb);
    }
}
