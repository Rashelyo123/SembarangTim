using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;

    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowSettings();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    void StartGame()
    {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene("GamePlay");
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    void ShowSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OnSettingsIconClick()
    {
        ShowSettings();
    }
}
