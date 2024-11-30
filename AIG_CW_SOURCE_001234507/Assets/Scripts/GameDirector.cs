using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameDirector : MonoBehaviour
{
    [Header("Game Object References")]
    public GameObject player;
    //public GameObject enemy;
    public GameObject easySpawner;
    public GameObject mediumSpawner;
    public GameObject hardSpawner;

    private EnemySpawner SpawnerE;
    private EnemySpawner SpawnerM;
    private EnemySpawner SpawnerH;

    [Header("Values")]
    [SerializeField] private int kills;
    [SerializeField] private int currentEnemies;
    [SerializeField] private int playerDeaths;
    [SerializeField] private int playerScore;

    [Header("Threshold to Change to Easy")]
    [SerializeField] private int ePlayerDeaths;



    [Header("Threshold to Change to Medium")]
    [SerializeField] private int mKills;
    [SerializeField] private int mPlayerDeaths;
    [SerializeField] private int mPlayerScore;

    [Header("Threshold to change to Hard")]
    [SerializeField] private int hKills;
    [SerializeField] private int hPlayerDeaths;
    [SerializeField] private int hPlayerScore;

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
        SpawnerE = easySpawner.GetComponent<EnemySpawner>();
        SpawnerM = mediumSpawner.GetComponent<EnemySpawner>();
        SpawnerH = hardSpawner.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackValues();

        if (Input.GetButtonDown("Fire2"))
        {
            playerDeaths += 1;
        }

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

        if (playerDeaths % ePlayerDeaths == 0) // for every 20 deaths 
        {
            currentDifficulty = Difficulties.EASY;
        }
        if (kills > mKills && playerDeaths < mPlayerDeaths || playerScore > mPlayerScore)
        {
            currentDifficulty |= Difficulties.MEDIUM;
        }
        if (kills > hKills && playerDeaths < hPlayerDeaths || playerScore > hPlayerScore)
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
                HardDifficulty();
                break;
            case Difficulties.MEDIUM:
                print("Medium");
                MediumDifficulty();
                break;
            case Difficulties.EASY:
                print("Easy");
                EasyDifficulty();
                break;

        }
    }


    void EasyDifficulty()
    {
        // spawnrate of like 3
        SpawnerE.SetSpawnRate(3);
        easySpawner.SetActive(true);
        mediumSpawner.SetActive(false);
        hardSpawner.SetActive(false);
    }

    void MediumDifficulty()
    {
        // lower spawn rate for easy

        SpawnerE.SetSpawnRate(5);

        

        easySpawner.SetActive(true);
        mediumSpawner.SetActive(true);
        hardSpawner.SetActive(false);
    }

    void HardDifficulty()
    {
        // Change spawnrates 
        // lower spawnrates for easy and medium
        SpawnerE.SetSpawnRate(6);
        SpawnerM.SetSpawnRate(5);
        SpawnerH.SetSpawnRate(5);
        easySpawner.SetActive(true);
        mediumSpawner.SetActive(true);
        hardSpawner.SetActive(true);
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
