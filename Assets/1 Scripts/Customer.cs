using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
	public Burger wantedBurger;

	private void Start()
	{
		wantedBurger = GetNewBurger();
		
		Debug.Log($"<color=orange>WANTED BURGER: {wantedBurger}</color>");
		for (int i = 0; i < wantedBurger.resources.Count; i++)
		{
			Debug.Log($"Burger resource: {wantedBurger.resources[i].type}");
			
		}
	}

	//VISUALIZE WANTED BURGER
    public Burger GetNewBurger()
    {
	    List<Resource> resources = new List<Resource>();
	    Resource newResource = new Resource(ResourceType.BreadBottom);
	    resources.Add(newResource);
	    
	    Resource newResource2 = new Resource(ResourceType.Cheese);
	    AddNewResource(newResource2, resources);
	    Resource newResource3 = new Resource(ResourceType.Onion);
	    AddNewResource(newResource3, resources);
	    Resource newResource4 = new Resource(ResourceType.Meat);
	    AddNewResource(newResource4, resources);
	    Resource newResource5 = new Resource(ResourceType.Lettuce);
	    AddNewResource(newResource5, resources);
	    Resource newResource6 = new Resource(ResourceType.Tomato);
	    AddNewResource(newResource6, resources);
	    
	    Resource newResource7 = new Resource(ResourceType.BreadTop);
	    resources.Add(newResource7);

	    Burger burger = new Burger(resources);
	    return burger;
    }

    private void AddNewResource(Resource newResource, List<Resource> resources)
    {
	    float r = Random.value;
	    if (r < 0.5f)
	    {
		    resources.Add(newResource);
	    }
    }
    //IF WAIT LONG TIME ANGRY
    //BUY BURGER
}
