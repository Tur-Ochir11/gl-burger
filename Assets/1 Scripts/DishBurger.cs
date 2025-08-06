using System;
using System.Collections.Generic;
using DG.Tweening;
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
    public BoxCollider collider;
    private bool isBuy;
    [Header("Drag Settings")]
    [SerializeField] LayerMask layer;
    private bool isGrabbing = false;
    public float speed = 5;
    public float dragY = 5;
    private Vector3 hitPoint;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isGrabbing)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(ray, out RaycastHit hit, layer))
            {
                hitPoint = hit.point;
            }

            var targetPos = new Vector3(hitPoint.x, dragY, hitPoint.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
    private void OnMouseDown()
    {
        Grab();
    }

    private void OnMouseUp()
    {
        Drop();
    }

    private void Grab()
    {
        isGrabbing = true;
        rb.isKinematic = true;
        // outline.enabled = true;
    }

    private void Drop()
    {
        isGrabbing = false;
        rb.isKinematic = false;
        // outline.enabled = false;

        // if (!firstDrop)
        // {
        //     OnFirstDrop?.Invoke();
        //     firstDrop = true;
        // }
    }

    public void AddResourceHandler(ResourceHandler resourceHandler)
    {
        resourceHandler.enabled = false;
        resourceHandler.SetParent(transform);
        resourceHandler.transform.DOLocalMove(resourcePoint, 0.25f).SetEase(Ease.InOutSine).OnComplete((() =>
        {
            resourceHandler.transform.DOScale(1f, 0.3f).From(0.7f).SetEase(Ease.OutBack);
        }));
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

    private void OnCollisionEnter(Collision other)
    {
        if (isBuy) return;
        // Debug.Log(other.collider.name);
        if (other.transform.TryGetComponent(out Customer customer))
        {
            isBuy = true;
            customer.BuyBurger(this);
            collider.enabled = false;
        }
    }
}
