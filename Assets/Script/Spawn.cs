using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    List<Transform> spawnPositions;

    [SerializeField]
    float timeBetweenSpawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (Player.instance != null)
        {
            int indexSpawn = Random.Range(0, spawnPositions.Count);

            // SPAWN ENEMY
            Instantiate(enemyPrefab, spawnPositions[indexSpawn].position, spawnPositions[0].rotation);

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
