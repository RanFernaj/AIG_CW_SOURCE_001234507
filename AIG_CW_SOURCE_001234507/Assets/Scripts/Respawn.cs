using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != player.gameObject.activeInHierarchy)
        {
            gameDirector.AddPlayerDeaths(1);
            RespawnPlayer();

        }

        //if (Input.GetButtonDown("Fire2"))
        //{
        //    Debug.Log("Respawn!");
        //}

    }

    void RespawnPlayer()
    {
        
        player.transform.position = respawnPoint.position;
        player.SetActive(true);
        
        PlayerDamage damage = player.GetComponent<PlayerDamage>();
        damage.TakeDamage(-50); // Setting player health back to normal

    }

   
}
