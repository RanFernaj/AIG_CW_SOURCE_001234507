using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health = 50f;
    //public GameDirector gameDirector;

    public void TakeDamage(float amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            GameDirector gameDirector = FindObjectOfType<GameDirector>();
            gameDirector.AddPlayerKills(1);
            gameDirector.AddPlayerScore(100);
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
