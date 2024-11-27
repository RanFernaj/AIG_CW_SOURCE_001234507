using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != player.gameObject.activeInHierarchy)
        {
            RespawnPlayer();
        }

        

    }

    void RespawnPlayer()
    {
        
        player.position = respawnPoint.position;
        //player.SetActive(true);
    }

   
}
