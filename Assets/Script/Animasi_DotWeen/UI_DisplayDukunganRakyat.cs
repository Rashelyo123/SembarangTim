using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Globalization;

public class UI_DisplayDukunganRakyat : MonoBehaviour
{
    public static UI_DisplayDukunganRakyat instance;
    public TextMeshProUGUI sessionDukunganRakyatText;
    public TextMeshProUGUI totalDukunganRakyatText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateSessionDukunganRakyat(int oldDukunganRakyat, int newScore)
    {
        if (sessionDukunganRakyatText == null)
        {
            Debug.LogError("sessionDukunganRakyatText BELUM DISET! Pastikan objek UI di-assign di Inspector.");
            return;
        }

        DOTween.To(() => oldDukunganRakyat, x =>
        {
            sessionDukunganRakyatText.text = "+" + x.ToString("N0", new CultureInfo("id-ID"));
        }, newScore, 1f).SetEase(Ease.OutQuad);
    }
    public void ShowFinalDukunganRakyat(int totalDukungan)
    {
        if (totalDukunganRakyatText == null)
        {
            Debug.LogError("totalDukunganRakyatText belum di-assign di Inspector!");
            return;
        }

        totalDukunganRakyatText.text = "0"; // Mulai dari 0
        DOTween.To(() => 0, x =>
        {
            totalDukunganRakyatText.text = "Jumlah Suara terkumpul : " + x.ToString("N0", new CultureInfo("id-ID"));
        }, totalDukungan, 2f).SetEase(Ease.OutExpo);
    }
}
