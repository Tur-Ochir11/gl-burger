using System;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    public List<Resource> resources = new List<Resource>();
    public Vector3 resourcePoint;
    public BoxCollider addTrigger;

    public void AddResource(Resource resource)
    {
        resource.enabled = false;
        resource.SetParent(transform);
        resource.transform.localPosition = resourcePoint;
        resources.Add(resource);
        resourcePoint += resource.offsetUp;
        AddTriggerHeight(resource.offsetUp);
    }

    private void AddTriggerHeight(Vector3 add)
    {
        addTrigger.center += add;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            AddResource(resource);
        }
    }
}
