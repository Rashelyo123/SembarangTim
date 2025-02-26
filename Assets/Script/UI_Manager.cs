using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{

    public GameObject CurrencyPurcase;
    public GameObject GameOverPanel;
    public Animator anim;
    public Animator anim2;
    public void PurchasePageCurrency()
    {
       StartCoroutine(Delay());
    }
    public void UseDukunganRakyat()
    {
        GameManager.instance.ContinueGame();
    }
    public void AnimUIContinueGame()
    {
       // StartCoroutine(Delay2());
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerator Delay(){
        
        anim.SetTrigger("Close");
        yield return new WaitForSeconds(1);
        CurrencyPurcase.SetActive(true);
          GameOverPanel.SetActive(false);
       
    }
    private IEnumerator Delay2(){
        
        anim2.SetTrigger("Close");
        yield return new WaitForSeconds(1);
        CurrencyPurcase.SetActive(false);
          
       
    }
}
