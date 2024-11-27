using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health = 50f;
    public GameDirector gameDirector;

    public void TakeDamage(float amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            gameDirector.AddPlayerKills(1);
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
