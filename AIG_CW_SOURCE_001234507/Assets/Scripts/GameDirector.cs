using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Game Object References")]
    public GameObject player;
    public GameObject enemy;

    [Header("Values")]
    public int kills;
    public int currentEnemies;
    public enum Difficulties 
    {
        EASY, 
        MEDIUM, 
        HARD
    };
    public Difficulties currentDifficulty;

    // Have different fucntions for each difficulty 
    // For each difficulty ther should be a min and max value
    // Probabilty caluclation should also occur here 
    // When a value for a gameobject ie. Enemy or spawner 
    // 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
