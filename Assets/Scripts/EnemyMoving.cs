using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private Vector2[] waypoints;
    private RoadsScript roads;
    private Rigidbody2D enemyRigidbody;
    private int waypoint = 0;
    private bool notMoving = true;
    private Vector2 direction;
    void Start()
    {
        roads = RoadsScript.FindObjectOfType<RoadsScript>();
        waypoints = roads.GetWaypoints();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 direction = GetDirection();
        enemyRigidbody.velocity = gameObject.CompareTag("EnemyTank")? direction * 0.5f: direction * 0.75f;         
        enemyRigidbody.MoveRotation(Quaternion.LookRotation(direction));
    }

    private Vector2 GetDirection()
    {
        if (notMoving)
        {
            direction = (new Vector3(waypoints[waypoint].x, waypoints[waypoint].y) - transform.position).normalized;
            notMoving = false;
        }
        if (waypoints[waypoint].x == System.Math.Round(transform.position.x, 1) && waypoints[waypoint].y == System.Math.Round(transform.position.y, 1))
        {
            if (gameObject.CompareTag("EnemyTank"))
            {
                waypoint++;
            }
            else
            {
                waypoint += 2;
            }
            notMoving = true;
        }
        return direction;
    }
}
