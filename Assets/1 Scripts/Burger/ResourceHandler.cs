using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Resource
{
    public ResourceType type;

    public Resource(ResourceType newType)
    {
        type = newType;
    }
}

public class ResourceHandler : MonoBehaviour
{
    public Resource resource;
    
    public Vector3 offsetUp;
    [Header("Drag settings")]
    [SerializeField] LayerMask layer;
    public float speed = 5;
    public float dragY = 5;
    private Rigidbody rb;
    private Outline outline;
    private bool isGrabbing = false;
    private Vector3 hitPoint;
    private Collider collider;
    
    public UnityAction OnFirstDrop;
    private bool firstDrop = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        outline = GetComponentInChildren<Outline>();
        collider = GetComponentInChildren<Collider>();
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

    private void OnDrawGizmos()
    {
        if (!isGrabbing) return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPoint, 0.1f);
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
        outline.enabled = true;
    }

    private void Drop()
    {
        isGrabbing = false;
        rb.isKinematic = false;
        outline.enabled = false;

        if (!firstDrop)
        {
            OnFirstDrop?.Invoke();
            firstDrop = true;
        }
    }

    public void SetParent(Transform parent)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        outline.enabled = false;
        rb.isKinematic = true;
        collider.enabled = false;
        transform.SetParent(parent);
    }
}
