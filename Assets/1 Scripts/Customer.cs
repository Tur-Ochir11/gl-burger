using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
	public Burger wantedBurger;

	private void Start()
	{
		wantedBurger = CreateNewBurger();
		
		// Debug.Log($"<color=orange>WANTED BURGER: {wantedBurger}</color>");
		// for (int i = 0; i < wantedBurger.resources.Count; i++)
		// {
		// 	Debug.Log($"Burger resource: {wantedBurger.resources[i].type}");
		// }
	}

	//VISUALIZE WANTED BURGER
    public Burger CreateNewBurger()
    {
	    List<Resource> resources = new List<Resource>();
	    Resource BreadBottom = new Resource(ResourceType.BreadBottom);
	    resources.Add(BreadBottom);
	    
	    Resource Cheese = new Resource(ResourceType.Cheese);
	    AddNewResource(Cheese, resources);
	    Resource Onion = new Resource(ResourceType.Onion);
	    AddNewResource(Onion, resources);
	    Resource Meat = new Resource(ResourceType.Meat);
	    AddNewResource(Meat, resources, 0.75f);
	    Resource Lettuce = new Resource(ResourceType.Lettuce);
	    AddNewResource(Lettuce, resources);
	    Resource Tomato = new Resource(ResourceType.Tomato);
	    AddNewResource(Tomato, resources);
	    
	    Resource BreadTop = new Resource(ResourceType.BreadTop);
	    resources.Add(BreadTop);

	    Burger burger = new Burger(resources);
	    return burger;
    }

    private void AddNewResource(Resource newResource, List<Resource> resources, float chance = 0.5f)
    {
	    float r = Random.value;
	    if (r < chance)
	    {
		    resources.Add(newResource);
	    }
    }
    //IF WAIT LONG TIME ANGRY
    //BUY BURGER
    public void BuyBurger(DishBurger dishBurger)
    {
	    if (Utilities.AreSameBurgers(dishBurger.burger, wantedBurger))
	    {
		    Debug.Log("<color=green>Same Burger</color>");
		    Debug.Log("Giving money");
		    dishBurger.transform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete((() =>
		    {
			    Destroy(dishBurger.gameObject, 0.1f);
			    Exit();
		    }));
		    
	    }
	    else
	    {
		    Debug.Log("<color=red>Not Same Burger</color>");
	    }
    }

    public void Exit()
    {
	    //NAV MESH SET DESTINATION
	    Destroy(gameObject, 0.1f);
    }
}
