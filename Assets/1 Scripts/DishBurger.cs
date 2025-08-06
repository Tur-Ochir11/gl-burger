using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Burger
{
    public List<Resource> resources = new List<Resource>();
    public Burger(List<Resource> newResources)
    {
        resources = newResources;
    }
}

public class DishBurger : MonoBehaviour
{
    public Burger burger;
    public Vector3 resourcePoint;
    public BoxCollider addTrigger;

    public void AddResourceHandler(ResourceHandler resourceHandler)
    {
        resourceHandler.enabled = false;
        resourceHandler.SetParent(transform);
        resourceHandler.transform.localPosition = resourcePoint;
        burger.resources.Add(resourceHandler.resource);
        resourcePoint += resourceHandler.offsetUp;
        AddTriggerHeight(resourceHandler.offsetUp);
    }

    private void AddTriggerHeight(Vector3 add)
    {
        addTrigger.center += add;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ResourceHandler resource))
        {
            AddResourceHandler(resource);
        }
    }
}
