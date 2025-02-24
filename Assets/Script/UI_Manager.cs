using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{

    public GameObject CurrencyPurcase;
    public GameObject GameOverPanel;
    public void PurchasePageCurrency()
    {
        CurrencyPurcase.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void UseDukunganRakyat()
    {
        GameManager.instance.ContinueGame();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
