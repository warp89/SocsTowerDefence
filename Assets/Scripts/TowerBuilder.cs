using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private UpgradeTower upgradeLevel;
    private GameObject towerBase;
    private GameObject towerBaseBuild;
    private GameObject[] turrets;
    private GameObject shootRange;
    private GameObject shootRangeBase;
    private int currentLevel;

    void Start()
    {
        upgradeLevel = GetComponentInChildren<UpgradeTower>();
        towerBase = Resources.Load<GameObject>("Prefabs/TowerBase");
        shootRange = Resources.Load<GameObject>("Prefabs/ShootRange");
        turrets = new GameObject[5] { Resources.Load<GameObject>("Prefabs/Barrel1"),
            Resources.Load<GameObject>("Prefabs/Barrel0"),
            Resources.Load<GameObject>("Prefabs/Barrel2"),
            Resources.Load<GameObject>("Prefabs/Barrel10"),
            Resources.Load<GameObject>("Prefabs/Barrel12")};
        currentLevel = upgradeLevel.towerLevel;
    }


    void Update()
    {
        if (currentLevel != upgradeLevel.towerLevel)
        {
            switch (upgradeLevel.towerLevel)
            {
                case 0: ZeroLevel(); break;
                case 1: LevelOne(); break;
                case 2: LevelTwo(); break;
                case 3: LevelThree(true); break;
                case 4: LevelFour(true); break;
                case 5: LevelThree(false); break;
                case 6: LevelFour(false); break;
                default:
                    break;
            }
            currentLevel = upgradeLevel.towerLevel;
        }

    }
    /// <summary>
    /// Define damage via type of enemy
    /// </summary>
    /// <param name="type">type of enemy</param>
    /// <returns></returns>
    public int HowMutchDamage(string type)
    {
        int damage = 1;
        if (type == "EnemyTank" && currentLevel == 5 || type == "EnemyPlane" && currentLevel == 3)
        {
            damage *= 2;
        }
        if (type == "EnemyTank" && currentLevel == 6 || type == "EnemyPlane" && currentLevel == 4)
        {
            damage *= 4;
        }
        return damage;
    }
    private void ZeroLevel()
    {
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
    private void LevelOne()
    {
        towerBaseBuild = Instantiate(towerBase, transform.position, Quaternion.identity, transform);
    }
    private void LevelTwo()
    {
        shootRangeBase = Instantiate(shootRange, transform.position, Quaternion.identity, towerBaseBuild.transform);
        Instantiate(turrets[0], transform.position, Quaternion.identity, shootRangeBase.transform);
    }
    private void LevelThree(bool type)
    {
        Destroy(shootRangeBase.transform.GetChild(0).gameObject);
        if (type)
        {
            Instantiate(turrets[2], transform.position, Quaternion.identity, shootRangeBase.transform);
        }
        else
        {
            Instantiate(turrets[1], transform.position, Quaternion.identity, shootRangeBase.transform);
        }

    }
    private void LevelFour(bool type)
    {
        Destroy(shootRangeBase.transform.GetChild(0).gameObject);
        if (type)
        {
            Instantiate(turrets[4], transform.position, Quaternion.identity, shootRangeBase.transform);
        }
        else
        {
            Instantiate(turrets[3], transform.position, Quaternion.identity, shootRangeBase.transform);
        }
    }
}
