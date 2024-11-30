using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerDamage damage = other.gameObject.GetComponent<PlayerDamage>();

            if (damage != null)
            {
                damage.TakeDamage(10000);
            }
        }
    }
}
