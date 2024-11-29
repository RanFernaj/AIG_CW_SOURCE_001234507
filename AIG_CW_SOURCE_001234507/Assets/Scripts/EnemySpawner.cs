using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies());
    }
}
