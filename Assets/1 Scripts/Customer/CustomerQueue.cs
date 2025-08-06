using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    [Header("Queue Point")]
    public List<Vector3> queuePoint = new List<Vector3>();
    public float pointDistance = 3;
    public List<Customer> queueCustomers = new List<Customer>();

    private void Awake()
    {
        UpdatePoints();
    }

    public void AddCustomer(Customer customer)
    {
        customer.OnExit += RemoveCustomer;
        queueCustomers.Add(customer);
        
        UpdateCustomer();
    }

    public void UpdateCustomer()
    {
        // Debug.Log($"queueCustomers.Count: {queueCustomers.Count}");
        for (int i = 0; i < queueCustomers.Count; i++)
        {
            queueCustomers[i].Move(queuePoint[i]);
        }
    }

    public void RemoveCustomer()
    {
        queueCustomers.RemoveAt(0);
        
        UpdateCustomer();
    }

    private void UpdatePoints()
    {
        for (int i = 0; i < 10; i++)
        {
            queuePoint.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z + i * pointDistance));
        }
    }
}
