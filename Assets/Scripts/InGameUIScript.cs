using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIScript : MonoBehaviour
{
    private GameSettings settings;
    private Text wave;
    private Text money;
    private Text lives;

    void Start()
    {
        settings = FindObjectOfType<GameSettings>();
        wave = GameObject.Find("Wave").GetComponent<Text>();
        money = GameObject.Find("Money").GetComponent<Text>();
        lives = GameObject.Find("Lives").GetComponent<Text>();
    }

    
    void Update()
    {
        wave.text = $"Ост. времени: {Mathf.RoundToInt(settings.GetTime())}";
        money.text = $"$:{settings.GetMoney()}";
        lives.text = $"Жизней:{settings.GetLives()}";
    }
}
