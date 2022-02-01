using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private GameObject[] enemyTank;
    private float timeToCreate;
    private int multipler = 2;
    private int multipler2 = 2;
    private float waitingTime = 5;
    private bool spawner = false;
    void Start()
    {
        timeToCreate = 2;
        enemyTank = new GameObject[2] { Resources.Load<GameObject>("Prefabs/EnemyTank"), Resources.Load<GameObject>("Prefabs/EnemyPlane") };
    }

    private void CreateTank()
    {
        Instantiate(enemyTank[Random.Range(0, enemyTank.Length)], transform.position, Quaternion.identity);
    }
    void Update()
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            waitingTime = 1000;
            spawner = true;
        }
        if (spawner)
        {
            timeToCreate -= Time.deltaTime;
            if (timeToCreate <= 0)
            {
                CreateTank();
                timeToCreate = 1.5f;
                multipler2--;
            }
            if (multipler2 <= 0)
            {
                spawner = false;
                waitingTime = 10;
                multipler *= 2;
                multipler2 = multipler;
            }

        }
    }
}
