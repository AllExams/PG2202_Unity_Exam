using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // the game object to spawn
    public float spawnTime; // the initial spawn time
    public float spawnTimeDecrement; // how much the spawn time decreases each time
    public Transform platform; // the platform on which to spawn the objects

    private float timer; // keeps track of how much time has passed
    
    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTime -= spawnTimeDecrement * Time.deltaTime;
        spawnTime = Mathf.Max(spawnTime, 0.1f); // ensure spawn time is not negative or zero
    }

    void SpawnObject()
    {
        float platformWidth = platform.localScale.x; // get the width of the platform
        float randomX = Random.Range(-platformWidth / 2f, platformWidth / 2f); // generate a random x position on the platform
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z); // create a spawn position vector
        GameObject enemy = Instantiate(prefab, spawnPosition, transform.rotation); // Spawn the object at the spawn position

        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>(); // Get the Enemy Movement component
        if (enemyMovement != null) // Check if the component exists
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Get a reference to the player object
            if (player != null) // Check if the player object exists
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>(); // Get the player's movement component
                if (playerMovement != null) // Check if the component exists
                {
                    enemyMovement.target = playerMovement.transform; // Set the target to be the player's Transform
                }
            }
        }
    }
}