using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new(0, 245, 4, 255);
    [SerializeField] Color32 noPackageColor = new(255, 255, 255, 255);

    private bool _hasPackage;
    [SerializeField] private float delay = 0.5f;

    private SpriteRenderer _spriteRenderer;

    public Customer customerComponent;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        customerComponent = FindObjectOfType<Customer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Oh no, collision!!!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !_hasPackage)
        {
            Debug.Log("Package picked up");
            _hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }

        if (other.CompareTag($"Customer") && _hasPackage)
        {
            Debug.Log("Customer picked up delivery");
            _spriteRenderer.color = noPackageColor;
            _hasPackage = false;
            customerComponent.SpriteChange();
        }
    }
}