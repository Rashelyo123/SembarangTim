using UnityEngine;
using TMPro;
using DG.Tweening;
public class UI_DisplayDukunganRakyat : MonoBehaviour
{
    public static UI_DisplayDukunganRakyat instance;
    public TextMeshProUGUI dukunganRakyatText;
    private void Awake()
    {
        instance = this;
    }
    public void UpdateDukunganRakyat(int oldDukunganRakyat, int NewScore)
    {
        DOTween.To(() => oldDukunganRakyat, x =>
        {
            oldDukunganRakyat = x;
            dukunganRakyatText.text = "+" + oldDukunganRakyat.ToString();
        }, NewScore, 1f).SetEase(Ease.OutQuad);
    }
}
