using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject winLosePanel;
    private int enemiesOnFinish = 5;
    private int playerMoney = 1000;
    private int enemiesCounter;
    private int basePrice = 100;
    private bool ableToBuild;
    private float gameTime;
    private float winTime;
    private bool alreadySpeld;

    private void Start()
    {        
        winTime = 4f * 60;
        enemiesCounter = 0;
        Pause(0);
        ableToBuild = false;
        alreadySpeld = false;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        if (enemiesCounter >= enemiesOnFinish && !alreadySpeld)
        {
            WinLoseGame(false);           
        }
        if (gameTime > winTime && !alreadySpeld)
        {
            WinLoseGame(true);            
        }
    }
    private void WinLoseGame(bool result)
    {
        ableToBuild = false;
        Pause(0);
        GameObject.FindGameObjectWithTag("InGameUI").SetActive(false);        
        winLosePanel.SetActive(true);
        winLosePanel.transform.GetChild(1).GetComponent<Text>().text = result ? "Ты выиграл!" : "Ты проиграл!";
        alreadySpeld = true;
    }
    public void Pause(int timeScale)
    {
        Time.timeScale = timeScale;
    }
    public bool AbilityToBuild()
    {
        return ableToBuild;
    }
    public void AbilityToBuild(bool able)
    {
        ableToBuild = able;
    }
    public void EnemyOnFinish()
    {
        enemiesCounter++;
    }
    public bool RequestMoney(int sum)
    {
        if (sum > playerMoney)
        {
            return false;
        }
        return true;
    }
    public void SpendMoney(int sum)
    {
        playerMoney -= sum;
    }
    public int GetPrice(int upgradeNumber)
    {
        int currentPrice = basePrice;
        for (int i = 1; i < upgradeNumber; i++)
        {
            currentPrice *= 2;
        }
        return currentPrice;
    }
    public int GetMoney()
    {
        return playerMoney;
    }
    public int GetLives()
    {
        return enemiesOnFinish - enemiesCounter;
    }
    public float GetTime()
    {
        return winTime - gameTime;
    }
}
