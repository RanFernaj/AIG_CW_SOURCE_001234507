using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameDirector gameDirector;

    [SerializeField] private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        EnemyStateMachine enemy = enemyPrefab.GetComponent<EnemyStateMachine>();
        if (gameDirector.currentDifficulty == 0) 
        {
            enemy.walkSpeed = Random.Range(5, 10);
        }
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemies());
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }
}
