using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public CustomerQueue queue;
    private void Start()
    {
        StartCoroutine(DelayedSpawn(5, 0.25f));
    }

    IEnumerator DelayedSpawn(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
            yield return new WaitForSeconds(delay);
        }
        // Spawn();
    }

    private void Spawn()
    {
        var newCustomer = Instantiate(customerPrefab, transform.position, transform.rotation, transform);
        var c = newCustomer.GetComponent<Customer>();
        // c.Move();
        c.OnExit += Spawn;
        queue.AddCustomer(c);
    }
    
}
