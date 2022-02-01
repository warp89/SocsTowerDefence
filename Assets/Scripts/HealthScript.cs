using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private float maxHealth;
    private float health;
    private GameSettings settings;
    void Start()
    {
        settings = FindObjectOfType<GameSettings>();
        maxHealth = gameObject.CompareTag("EnemyTank") ? 50 : 35;
        health = maxHealth;
    }
    public void SetDamage(float damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (transform.position.x > 11)
        {
            Destroy(gameObject);
        }
        if (health < 0)
        {
            settings.SpendMoney(-settings.GetPrice(1));
            Destroy(gameObject);
        }
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
