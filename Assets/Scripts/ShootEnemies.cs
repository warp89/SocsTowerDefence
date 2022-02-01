using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private TowerRotation towerRotation;
    private TowerBuilder towerBuilder;
    private GameObject fireFlame;
    private float reloadTime;
    private float timeToReload;    
    private void Start()
    {        
        timeToReload = 0.25f;
        reloadTime = 0;
        towerBuilder = GetComponentInParent<TowerBuilder>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null)
        {
            if (collision.CompareTag("EnemyTank") || collision.CompareTag("EnemyPlane"))
            {
                target = collision.gameObject;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null)
        {
            if (collision.CompareTag("EnemyTank") || collision.CompareTag("EnemyPlane"))
            {
                target = collision.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyTank")||collision.CompareTag("EnemyPlane"))
        {
            target = null;
        }
    }
    private void Update()
    {
        if (fireFlame == null|| towerRotation == null)
        {
            fireFlame = gameObject.transform.GetChild(0).GetChild(0).gameObject;
            towerRotation = GetComponentInChildren<TowerRotation>();
        }
        Shooting();
        towerRotation.TurnTower(target);
    }
    private void Shooting()
    {        
        reloadTime -= Time.deltaTime;
        if (target != null)
        {
            if (reloadTime <= 0)
            {
                fireFlame.SetActive(true);
                target.GetComponent<HealthScript>().SetDamage(towerBuilder.HowMutchDamage(target.tag));
                reloadTime = timeToReload;
                StartCoroutine(FireFlameOff());
            }
        }
    }
    IEnumerator FireFlameOff()
    {
        yield return new WaitForSeconds(0.05f);
        fireFlame.SetActive(false);
    }
}
