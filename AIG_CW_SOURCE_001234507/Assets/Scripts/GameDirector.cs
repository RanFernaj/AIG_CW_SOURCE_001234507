using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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



    public enum Difficulties 
    {
        EASY, 
        MEDIUM, 
        HARD
    };

    [Header("Difficulty")]
    public Difficulties currentDifficulty;

    // Have different fucntions for each difficulty 
    // For each difficulty ther should be a min and max value
    // Probabilty caluclation should also occur here 
    // When a value for a gameobject ie. Enemy or spawner needs to change is done incapsulation (Get/Set)

    // Values that will change--> Enemy Health, Spawn rates, enemy damage,  
    // For player deaths --> DIsable player obj, wait time, set player to respawn point, reenable player (Use coroutine)
    // Values to be tracked --> playerkill score(Done), player kills(done), player deaths(Done), current enemeies(done)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackValues();
    }
    private void FixedUpdate()
    {
        UpdateDifficulty();
        CheckForEnemies();
    }

    void CheckForEnemies()
    {
        var enemies = FindObjectsOfType<Damage>();
        currentEnemies = enemies.Length;
    }

    public void TrackValues()
    {
        if(kills > 0)
        {
            currentDifficulty = Difficulties.HARD;
        }
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
    
    public void AddPlayerScore(int amount)
    {
        playerScore += amount;
    }

    public int GetPlayerKill()
    {
        return kills;
    }

    public int GetPlayerDeaths()
    {
        return playerDeaths;
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }
}
