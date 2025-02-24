using System.Collections;
using TMPro;
using UnityEngine;
using System.Globalization;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI efficiencyText;
    [SerializeField] private TextMeshProUGUI sessionDukunganRakyatText;
    [SerializeField] private TextMeshProUGUI highScoreEfficiencyText;
    [SerializeField] private TextMeshProUGUI LastdukunganRakyatText;
    [SerializeField] private TextMeshProUGUI lastScoreText;
    [Header("Script Reference")]
    [SerializeField]
    public PlayerController PlayerController;
    public MoveSection moveSection;

    [Header("UI Display")]
    [SerializeField] private GameObject UI_HasilAkhir;

    [SerializeField] private GameObject UI_ContinueGame;

    private int totalEfficiency = 0;
    private int totalDukunganRakyat = 0;
    private int sessionDukunganRakyat = 0;
    private int highScoreEfficiency = 0;
    private int lastDukunganRakyat = 0;
    private int lastScore = 0;

    public int dukunganRakyatPerSecond = 10;
    private bool isGameRunning = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        highScoreEfficiency = PlayerPrefs.GetInt("HighScoreEfficiency", 0);
        totalDukunganRakyat = CurrencyManager.instance.GetDukunganRakyat();

        // Reset suara rakyat yang dikumpulkan selama sesi game
        sessionDukunganRakyat = 0;

        lastDukunganRakyat = 0;
        PlayerPrefs.SetInt("LastDukunganRakyat", lastDukunganRakyat);
        PlayerPrefs.Save();
        lastScore = 0;
        PlayerPrefs.SetInt("LastScore", lastScore);
        PlayerPrefs.Save();

        if (highScoreEfficiencyText != null)
            highScoreEfficiencyText.text = "High Score: Rp. " + highScoreEfficiency.ToString("N0", new CultureInfo("id-ID"));

        if (lastScoreText != null)
            lastScoreText.text = "Rp. " + lastScore.ToString("N0", new CultureInfo("id-ID"));
        if (LastdukunganRakyatText != null)
            LastdukunganRakyatText.text = " 0";



        if (sessionDukunganRakyatText != null)
            sessionDukunganRakyatText.text = " 0";
    }

    public void AddEfficiency(int amount)
    {
        totalEfficiency += amount;

        if (totalEfficiency > highScoreEfficiency)
        {
            highScoreEfficiency = totalEfficiency;
            PlayerPrefs.SetInt("HighScoreEfficiency", highScoreEfficiency);
            PlayerPrefs.Save();
        }

        if (efficiencyText != null)
            efficiencyText.text = "Rp. " + totalEfficiency.ToString("N0", new CultureInfo("id-ID"));
        UIEfficiencyDisplay.instance.UpdateEfficiency(totalEfficiency);

        if (highScoreEfficiencyText != null)
            highScoreEfficiencyText.text = "High Score: Rp. " + highScoreEfficiency.ToString("N0", new CultureInfo("id-ID"));
    }

    public void AddDukunganRakyat(int amount)
    {
        int oldSessionDukunganRakyat = sessionDukunganRakyat;


        sessionDukunganRakyat += amount;


        CurrencyManager.instance.AddDukunganRakyat(amount);
        totalDukunganRakyat = CurrencyManager.instance.GetDukunganRakyat();



        if (sessionDukunganRakyatText != null)
        {

            UI_DisplayDukunganRakyat.instance.UpdateSessionDukunganRakyat(oldSessionDukunganRakyat, sessionDukunganRakyat);
        }
    }

    private void Start()
    {
        isGameRunning = true;
        //StartCoroutine(DukunganRakyatPerSecond());
    }

    // private IEnumerator DukunganRakyatPerSecond()
    // {
    //     while (isGameRunning)
    //     {
    //          //AddDukunganRakyat(dukunganRakyatPerSecond);
    //         yield return new WaitForSeconds(0.3f);
    //     }
    // }
    public void StopGame()
    {
        MoveSection[] movingObjects = FindObjectsOfType<MoveSection>();

        foreach (MoveSection obj in movingObjects)
        {
            obj.NotMove();
        }
        // Hentikan semua PowerUpSpawner
        PowerUpSpawner[] spawners = FindObjectsOfType<PowerUpSpawner>();
        foreach (PowerUpSpawner spawner in spawners)
        {
            spawner.noSpawn();
        }
        UI_HasilAkhir.SetActive(true);
        moveSection.NotMove();

        isGameRunning = false;

        // Simpan skor terakhir sebelum animasi dimulai
        int oldLastDukunganRakyat = lastDukunganRakyat;
        lastDukunganRakyat = totalDukunganRakyat; // Ambil total yang sudah dikumpulkan
        PlayerPrefs.SetInt("LastDukunganRakyat", lastDukunganRakyat);
        PlayerPrefs.Save();

        int oldLastScore = lastScore;
        lastScore = totalEfficiency;
        PlayerPrefs.SetInt("LastScore", lastScore);
        PlayerPrefs.Save();

        UI_DisplayDukunganRakyat.instance.ShowFinalDukunganRakyat(totalDukunganRakyat);

        if (lastScoreText != null)
        {
            DOTween.To(() => oldLastScore, x =>
            {
                lastScoreText.text = "Rp. " + x.ToString("N0", new CultureInfo("id-ID"));
            }, lastScore, 1.5f).SetEase(Ease.OutQuad);
        }

        if (LastdukunganRakyatText != null)
        {
            DOTween.To(() => oldLastDukunganRakyat, x =>
            {
                LastdukunganRakyatText.text = "+" + x.ToString("N0", new CultureInfo("id-ID"));
            }, sessionDukunganRakyat, 1.5f).SetEase(Ease.OutQuad);
        }


        // StopCoroutine(DukunganRakyatPerSecond());
    }


    public void ContinueGame()
    {
        int cost = 1000;
        if (CurrencyManager.instance.UseDukunganRakyat(cost))
        {
            isGameRunning = true;
            UI_ContinueGame.SetActive(false);
            PlayerController.Life();
            moveSection.Move();
            MoveSection[] movingObjects = FindObjectsOfType<MoveSection>();
            foreach (MoveSection obj in movingObjects)
            {
                obj.Move();
            }
            // Aktifkan kembali PowerUpSpawner
            PowerUpSpawner[] spawners = FindObjectsOfType<PowerUpSpawner>();
            foreach (PowerUpSpawner spawner in spawners)
            {
                spawner.Spawn();
            }

            // StartCoroutine(DukunganRakyatPerSecond());
            Debug.Log("Game Dilanjutkan!");
        }
        else
        {
            Debug.Log("Dukungan Rakyat tidak cukup!");
        }
    }

}
