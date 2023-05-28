using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    ItemSpawner _itemSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _itemSpawner = FindObjectOfType<ItemSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            _itemSpawner.DestroyItem(other.gameObject);
        }
    }
}
