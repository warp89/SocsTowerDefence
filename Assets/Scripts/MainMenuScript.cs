using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private GameSettings settings;
    private void Start()
    {
        settings = FindObjectOfType<GameSettings>();
    }
    public void StartGame()
    {
        settings.Pause(1);
        settings.AbilityToBuild(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
