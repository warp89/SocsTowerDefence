using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower : MonoBehaviour
{
    [SerializeField] private GameObject buttonsPanel;
    private Transform parentTransform;
    private GameObject upgradePanel;
    private GameSettings settings;
    public int towerLevel;
    private void Start()
    {
        settings = FindObjectOfType<GameSettings>();
        towerLevel = 0;
        parentTransform = GameObject.Find("Canvas").transform;
    }
    private void OnMouseEnter()
    {
        if (settings.AbilityToBuild())
        {
            MouseMenu();
        }
    }
    private void MouseMenu()
    {
        upgradePanel = Instantiate(buttonsPanel, parentTransform);
        upgradePanel.transform.position = gameObject.transform.position;
        switch (towerLevel)
        {
            case 0: BuildBasementMenu(); break;
            case 1: BuildFirstTurretMenu(); break;
            case 2: ChooseBuildTurretMenu(); break;
            case 3: UpgradeTurretMenu(); break;
            case 4: OnlyDestroyMenu(); break;
            case 5: UpgradeTurretMenu(); break;
            case 6: OnlyDestroyMenu(); break;

            default:
                Destroy(upgradePanel.gameObject);
                break;
        }
    }
    private void OnMouseExit()
    {
        if (settings.AbilityToBuild())
        {
            Destroy(upgradePanel.gameObject);
        }
    }
    private Transform PanelTransform(int child)
    {
        return upgradePanel.transform.GetChild(child);
    }
    private int Price(int priceLevel)
    {
        return settings.GetPrice(priceLevel);
    }
    private void BuildBasementMenu()
    {
        PanelTransform(2).gameObject.SetActive(false);
        PanelTransform(0).gameObject.SetActive(false);
        ButtonSetting(PanelTransform(1), $"Построить основание ${Price(1)}", true, settings.RequestMoney(Price(1)), Price(1));
    }
    private void BuildFirstTurretMenu()
    {
        PanelTransform(1).gameObject.SetActive(false);
        ButtonSetting(PanelTransform(0), $"Построить турель ${Price(2)}", true, settings.RequestMoney(Price(2)), Price(2));
        ButtonSetting(PanelTransform(2), $"Снести башню +${Price(1)}", false, true, Price(1));
    }
    private void ChooseBuildTurretMenu()
    {
        ButtonSetting(PanelTransform(0), $"Турель ПВО ${Price(3)}", true, 0, settings.RequestMoney(Price(3)), Price(3));
        ButtonSetting(PanelTransform(1), $"Бронебойная тур. ${Price(3)}", true, 2, settings.RequestMoney(Price(3)), Price(3));
        ButtonSetting(PanelTransform(2), $"Снести башню +${Price(2)}", false, true, Price(2));
    }
    private void UpgradeTurretMenu()
    {
        PanelTransform(1).gameObject.SetActive(false);
        ButtonSetting(PanelTransform(0), $"Улучшить турель ${Price(4)}", true, settings.RequestMoney(Price(4)), Price(4));
        ButtonSetting(PanelTransform(2), $"Снести башню +${Price(3)}", false, true, Price(3));
    }
    private void OnlyDestroyMenu()
    {
        PanelTransform(0).gameObject.SetActive(false);
        PanelTransform(1).gameObject.SetActive(false);
        ButtonSetting(PanelTransform(2), $"Снести башню +${Price(3)}", false, true, Price(3));
    }
    /// <summary>
    /// Button settings
    /// </summary>
    /// <param name="button">button transform</param>
    /// <param name="buttonText">text at button</param>
    /// <param name="upgrade">upgrade or destroy</param>
    /// <param name="interactable">button is active?</param>
    /// <param name="price">price of purchase</param>
    private void ButtonSetting(Transform button, string buttonText, bool upgrade, bool interactable, int price)
    {
        button.GetComponent<Button>().interactable = interactable;
        button.GetComponentInChildren<Text>().text = buttonText;
        button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
        if (upgrade)
        {
            button.GetComponent<Button>().onClick.AddListener(() => InscreaseTowerLevel(price));
        }
        else
        {
            button.GetComponent<Button>().onClick.AddListener(() => DestroyTower(price / 2));
        }
    }
    /// <summary>
    /// Branch button settings
    /// </summary>
    /// <param name="button">button transform</param>
    /// <param name="buttonText">text at button</param>
    /// <param name="upgrade">upgrade or destroy</param>
    /// <param name="moreScores">transition to another branch</param>
    /// <param name="interactable">button is active?</param>
    /// <param name="price">price of purchase</param>
    private void ButtonSetting(Transform button, string buttonText, bool upgrade, int moreScores, bool interactable, int price)
    {
        button.GetComponent<Button>().interactable = interactable;
        button.GetComponentInChildren<Text>().text = buttonText;
        button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
        if (upgrade)
        {
            button.GetComponent<Button>().onClick.AddListener(() => InscreaseTowerLevel(moreScores, price));
        }
        else
        {
            button.GetComponent<Button>().onClick.AddListener(() => DestroyTower(price / 2));
        }
    }
    private void InscreaseTowerLevel(int price)
    {
        settings.SpendMoney(price);
        towerLevel++;
        RestartMenu();
    }
    private void InscreaseTowerLevel(int moreScores, int price)
    {
        settings.SpendMoney(price);
        towerLevel += moreScores;
        towerLevel++;
        RestartMenu();
    }
    private void DestroyTower(int price)
    {
        settings.SpendMoney(-price);
        towerLevel = 0;
        RestartMenu();
    }
    private void RestartMenu()
    {
        Destroy(upgradePanel.gameObject);
        MouseMenu();
    }
}

