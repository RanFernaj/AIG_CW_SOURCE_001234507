using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 15;
    public ParticleSystem damageParticle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // play effect here
            damageParticle.Play();  
            PlayerDamage playerDamage = other.transform.GetComponent<PlayerDamage>();
            if (playerDamage != null)
            {
                playerDamage.TakeDamage(damage);
            }

        }
    }
}
