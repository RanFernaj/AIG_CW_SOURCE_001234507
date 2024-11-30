using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Player Reference")]
    public PlayerDamage player;
    public GameDirector gameDirector;

    [Header("UI References")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI currentDiffText;


    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.GetHealth().ToString("0");
        killsText.text = "Kills: " + gameDirector.GetPlayerKill().ToString();
        scoreText.text = "Score: " + gameDirector.GetPlayerScore().ToString();
        deathsText.text = "Deaths: " + gameDirector.GetPlayerDeaths().ToString();


       currentDiffText.text = "Difficulty: "+gameDirector.currentDifficulty.ToString();
    }
}
