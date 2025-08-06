using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
	public Burger wantedBurger;
	private NavMeshAgent agent;
	private Animator animator;
	public UnityAction OnExit;
	
	[Header("UI")]
	public Image imagePrefab;
	public GridLayoutGroup gridLayoutGroup;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	private void Start()
	{
		wantedBurger = CreateNewBurger();
		CreateBurgerUI();
		
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
	    
	    Resource Lettuce = new Resource(ResourceType.Lettuce);
	    AddNewResource(Lettuce, resources);
	    Resource Meat = new Resource(ResourceType.Meat);
	    AddNewResource(Meat, resources, 0.75f);
	    Resource Onion = new Resource(ResourceType.Onion);
	    AddNewResource(Onion, resources);
	    Resource Cheese = new Resource(ResourceType.Cheese);
	    AddNewResource(Cheese, resources);
	    Resource Tomato = new Resource(ResourceType.Tomato);
	    AddNewResource(Tomato, resources);
	    
	    Resource BreadTop = new Resource(ResourceType.BreadTop);
	    resources.Add(BreadTop);

	    Burger burger = new Burger(resources);
	    return burger;
    }

    private void CreateBurgerUI()
    {
	    for (int i = 0; i < wantedBurger.resources.Count; i++)
	    {
		    var img = Instantiate(imagePrefab, gridLayoutGroup.transform);
		    img.sprite = Utilities.Instance.GetResourceSprite(wantedBurger.resources[i].type);
	    }
	    
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
	    OnExit?.Invoke();
	    Destroy(gameObject, 0.1f);
    }

    public void Move(Vector3 target)
    {
	    // Debug.Log($"Move {target}");
	    agent.SetDestination(target);
    }
}
