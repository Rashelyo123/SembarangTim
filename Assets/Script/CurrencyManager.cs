using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    private int dukunganRakyat;

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
            return;
        }

        // Load Dukungan Rakyat dari PlayerPrefs saat game dimulai
        dukunganRakyat = PlayerPrefs.GetInt("SavedDukunganRakyat", 0);
    }

    public int GetDukunganRakyat()
    {
        return dukunganRakyat;
    }

    public void AddDukunganRakyat(int amount)
    {
        dukunganRakyat += amount;
        PlayerPrefs.SetInt("SavedDukunganRakyat", dukunganRakyat);
        PlayerPrefs.Save();
    }

    public bool UseDukunganRakyat(int amount)
    {
        if (dukunganRakyat >= amount)
        {
            dukunganRakyat -= amount;
            PlayerPrefs.SetInt("SavedDukunganRakyat", dukunganRakyat);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }
}
