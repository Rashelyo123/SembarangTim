using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIEfficiencyDisplay : MonoBehaviour
{
    public TextMeshProUGUI efficiencyText;
    private int currentEfficiency = 0;
    public static UIEfficiencyDisplay instance;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateEfficiency(int newEfficiency)
    {
        DOTween.To(() => currentEfficiency, x =>
        {
            currentEfficiency = x;
            efficiencyText.text = "Rp." + currentEfficiency.ToString();
        }, newEfficiency, 0.5f).SetEase(Ease.OutQuad);

        efficiencyText.transform.DOScale(1.3f, 0.2f).SetEase(Ease.OutBack)
            .OnComplete(() => efficiencyText.transform.DOScale(1f, 0.2f));


        efficiencyText.transform.DOShakePosition(0.2f, 5f, 10, 90, false, true);


        efficiencyText.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 5, 0.5f);
    }
}
