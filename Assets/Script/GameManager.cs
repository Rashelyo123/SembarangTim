using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI efficiencyText;

    private int totalEfficiency = 0;
    private int totalDukunganRakyat = 0;

    public int dukunganRakyatPerSecond = 10;
    private bool isGameRunning = false;

    // Property untuk mengakses nilai
    public int TotalEfficiency => totalEfficiency = 0;
    public int TotalDukunganRakyat => totalDukunganRakyat = 0;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Agar GameManager tidak hilang saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isGameRunning = true;
        StartCoroutine(DukunganRakyatPerSecond());
    }

    public void AddEfficiency(int amount)
    {
        totalEfficiency += amount;
        if (efficiencyText != null)
        {
            efficiencyText.text = "Rp. " + totalEfficiency.ToString();
        }

        // Pastikan UIEfficiencyDisplay tidak null
        if (UIEfficiencyDisplay.instance != null)
        {
            UIEfficiencyDisplay.instance.UpdateEfficiency(totalEfficiency);
        }
    }

    public void AddDukunganRakyat(int amount)
    {
        int oldDukunganRakyat = totalDukunganRakyat;
        totalDukunganRakyat += amount;

        // Pastikan UI_DisplayDukunganRakyat tidak null
        if (UI_DisplayDukunganRakyat.instance != null)
        {
            UI_DisplayDukunganRakyat.instance.UpdateDukunganRakyat(oldDukunganRakyat, totalDukunganRakyat);
        }
    }

    private IEnumerator DukunganRakyatPerSecond()
    {
        while (isGameRunning)
        {
            AddDukunganRakyat(dukunganRakyatPerSecond);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void StopGame()
    {
        isGameRunning = false;
        StopCoroutine(DukunganRakyatPerSecond());
    }
}
