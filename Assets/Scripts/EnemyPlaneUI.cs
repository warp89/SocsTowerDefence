using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlaneUI : MonoBehaviour
{
    private GameObject healthPanel;
    private Transform parentTransform;
    private GameSettings settings;
    private GameObject enemyPanel;
    private Text healthBar;
    private HealthScript health;
    private float maxHealth;
    private float timeToDestroy = 1f;

    private void Start()
    {
        healthPanel = Resources.Load<GameObject>("Prefabs/EnemyPanelPlane");
        parentTransform = GameObject.Find("Canvas").transform;
        settings = FindObjectOfType<GameSettings>();
        health = GetComponent<HealthScript>();
    }
    private void OnMouseDown()
    {
        if (settings.AbilityToBuild())
        {
            enemyPanel = Instantiate(healthPanel, parentTransform);
            enemyPanel.transform.position = gameObject.transform.position;
            healthBar = enemyPanel.transform.GetChild(2).GetComponent<Text>();
            maxHealth = health.GetMaxHealth();
        }
    }
    
    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (enemyPanel != null)
        {
            enemyPanel.transform.position = gameObject.transform.position;
            healthBar.text = $"{health.GetHealth()}/{maxHealth}";
        }       
        
    }
}
