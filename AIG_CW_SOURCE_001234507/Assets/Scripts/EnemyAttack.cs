using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 15;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerDamage playerDamage = other.transform.GetComponent<PlayerDamage>();
            if (playerDamage != null)
            {
                playerDamage.TakeDamage(15);
            }

        }
    }
}
