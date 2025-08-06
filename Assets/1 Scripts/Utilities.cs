using System;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static Utilities Instance;
    public Sprite[] resourceTypeSprites;

    private void Awake()
    {
        Instance = this;
    }

    public static bool AreSameBurgers(Burger a, Burger b)
    {
        if (a.resources.Count != b.resources.Count) return false;
        
        for (int i = 0; i < a.resources.Count; i++)
        {
            if (a.resources[i].type != b.resources[i].type)
                return false;
        }
        return true;
    }

    public Sprite GetResourceSprite(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.BreadBottom:
                return resourceTypeSprites[0];
            case ResourceType.BreadTop:
                return resourceTypeSprites[1];
            case ResourceType.Meat:
                return resourceTypeSprites[2];
            case ResourceType.Onion:
                return resourceTypeSprites[3];
            case ResourceType.Lettuce:
                return resourceTypeSprites[4];
            case ResourceType.Tomato:
                return resourceTypeSprites[5];
            case ResourceType.Cheese:
                return resourceTypeSprites[6];
            default:
                return resourceTypeSprites[2];
        }
    }
}