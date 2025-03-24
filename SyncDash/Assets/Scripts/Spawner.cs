using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject[] obstaclePrefabs;  
    public GameObject[] orbPrefabs;       
    public Transform rightSpawnPoint;     
    public Transform leftSpawnPoint;
    public Transform rightOrbPoint;
    public Transform leftOrbPoint;
    public float minSpawnTime = 1f;      
    public float maxSpawnTime = 3f;      
    public float ghostDelay = 0.2f;      

    private Queue<(GameObject, Vector3)> ghostQueue = new Queue<(GameObject, Vector3)>();

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void GameStart()
    {
        StartCoroutine(SpawnObjects());
        StartCoroutine(ProcessGhostQueue());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            int spawnChoice = Random.Range(0, 3);

            if (spawnChoice == 1) SpawnObstacle();
            else if (spawnChoice == 2) SpawnOrb();
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject rightObstacle = Instantiate(obstacle, rightSpawnPoint.position, Quaternion.identity);
        ghostQueue.Enqueue((obstacle, leftSpawnPoint.position));
    }

    void SpawnOrb()
    {
        GameObject orb1 = orbPrefabs[0];
        GameObject orb2 = orbPrefabs[1];
        GameObject rightOrb = Instantiate(orb1, rightOrbPoint.position, Quaternion.identity);
        ghostQueue.Enqueue((orb2, leftOrbPoint.position));
    }

    IEnumerator ProcessGhostQueue()
    {
        while (true)
        {
            yield return new WaitForSeconds(ghostDelay);

            if (ghostQueue.Count > 0)
            {
                var (obj, position) = ghostQueue.Dequeue();
                Instantiate(obj, position, Quaternion.identity);
            }
        }
    }
}
