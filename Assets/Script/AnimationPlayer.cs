using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationPlayer : MonoBehaviour
{
    private Transform kamera;
    private Vector3 startPos;

    void Start()
    {
        kamera = Camera.main.transform;
        startPos = kamera.localPosition;

    }
    public void SetSLide()
    {
        Vector3 EndPos = startPos;
        EndPos.z = -5;
        kamera.DOLocalMove(EndPos, 0.5f);

    }
    public void SetUnSlide()
    {
        kamera.DOLocalMove(startPos, 0.2f);

    }
}
