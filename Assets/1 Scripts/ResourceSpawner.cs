using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject resourcePrefab;
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var newResource = Instantiate(resourcePrefab, transform.position, transform.rotation, transform);
        newResource.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).From(0);
        newResource.GetComponent<ResourceHandler>().OnFirstDrop += Spawn;
    }
    
}
