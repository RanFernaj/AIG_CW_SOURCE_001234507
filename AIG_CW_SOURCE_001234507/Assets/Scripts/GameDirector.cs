using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("Game Object References")]
    public GameObject player;
    public GameObject enemy;

    [Header("Values")]
    [SerializeField] private int kills;
    [SerializeField] private int currentEnemies;
    private enum Difficulties 
    {
        EASY, 
        MEDIUM, 
        HARD
    };
    [SerializeField] private Difficulties currentDifficulty;

    // Have different fucntions for each difficulty 
    // For each difficulty ther should be a min and max value
    // Probabilty caluclation should also occur here 
    // When a value for a gameobject ie. Enemy or spawner needs to change is done incapsulation (Get/Set)

    // Values that will change--> Enemy Health, Spawn rates, enemy damage,  
    // For player deaths --> DIsable player obj, wait time, set player to respawn point, reenable player (Use coroutine)
    // Values to be tracked --> playerkill score, player kills, player deaths
    //https://www.youtube.com/watch?v=yhlyoQ2F-NM (singleton tutorials)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
