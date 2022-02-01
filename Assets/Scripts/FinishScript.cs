using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private GameSettings settings;

    private void Start()
    {
        settings = FindObjectOfType<GameSettings>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.CompareTag("EnemyTank") || collision.CompareTag("EnemyPlane"))
        {
            settings.EnemyOnFinish();
            Destroy(collision.gameObject);
        }
    }
}
