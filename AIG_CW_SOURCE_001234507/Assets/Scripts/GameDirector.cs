using JetBrains.Annotations;
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
    [SerializeField] private int playerDeaths;
    [SerializeField] private int playerScore;

    private enum Difficulties 
    {
        EASY, 
        MEDIUM, 
        HARD
    };

    [Header("Difficulty")]
    [SerializeField] private Difficulties currentDifficulty;

    // Have different fucntions for each difficulty 
    // For each difficulty ther should be a min and max value
    // Probabilty caluclation should also occur here 
    // When a value for a gameobject ie. Enemy or spawner needs to change is done incapsulation (Get/Set)

    // Values that will change--> Enemy Health, Spawn rates, enemy damage,  
    // For player deaths --> DIsable player obj, wait time, set player to respawn point, reenable player (Use coroutine)
    // Values to be tracked --> playerkill score, player kills(done), player deaths(Done), current enemeies(done)
    //https://www.youtube.com/watch?v=yhlyoQ2F-NM (singleton tutorials)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckForEnemies();
    }

    void CheckForEnemies()
    {
        var enemies = FindObjectsOfType<Damage>();
        currentEnemies = enemies.Length;
    }

    public void TrackValues()
    {

    }

    void UpdateDifficulty()
    {
        switch (currentDifficulty)
        {
            case Difficulties.HARD:
                print("Hard mode");
                break;
            case Difficulties.MEDIUM:
                print("Medium");
                break;
            case Difficulties.EASY:
                print("Easy");
                break;

        }
    }


    void EasyDifficulty()
    {
        // Take The lower values and pick a random one
    }

    void MediumDifficulty()
    {
        // Take The middle(average) values and pick a random one
    }

    void HardDifficulty()
    {
        // Take The higher values and pick a random one
    }


    // Setters
    public void AddPlayerDeaths(int amount)
    {
        playerDeaths += amount;
    }
    
    public void AddPlayerKills(int amount)
    {
        kills += amount;
    }
}
