using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI efficiencyText;
    public TextMeshProUGUI votesText;
    public float animationDuration = 1.5f; // Durasi animasi perhitungan angka

    private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            int finalEfficiency = GameManager.instance.TotalEfficiency;
            int finalVotes = GameManager.instance.TotalDukunganRakyat;

            // Set nilai awal ke 0 agar terlihat efek bertambahnya
            efficiencyText.text = "- RP. 0";
            votesText.text = "0";

            // Animasi peningkatan angka dengan DOTween
            AnimateNumber(efficiencyText, 0, finalEfficiency, animationDuration, "RP. ");
            AnimateNumber(votesText, 0, finalVotes, animationDuration);
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }

    // Fungsi untuk animasi angka bertambah dengan DOTween
    private void AnimateNumber(TextMeshProUGUI textElement, int startValue, int endValue, float duration, string prefix = "")
    {
        DOTween.To(() => startValue, x =>
        {
            textElement.text = prefix + x.ToString("N0"); // Format angka agar lebih rapi
        }, endValue, duration).SetEase(Ease.OutQuad);
    }
}
