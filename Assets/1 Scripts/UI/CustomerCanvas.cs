using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerCanvas : MonoBehaviour
{
    public GameObject resourceParent;

    public float minShowDur = 2f;
    public float maxShowDur = 5f;
    
    public float minHideDur = 1f;
    public float maxHideDur = 3f;

    private void Start()
    {
        ShowResources();
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void ShowResources()
    {
        resourceParent.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).From(0);
        
        Invoke(nameof(HideResources), Random.Range(minShowDur, maxShowDur));
    }
    private void HideResources()
    {
        resourceParent.transform.DOScale(0f, 0.3f).SetEase(Ease.InBack).From(1);
        
        Invoke(nameof(ShowResources), Random.Range(minHideDur, maxHideDur));
    }
}
