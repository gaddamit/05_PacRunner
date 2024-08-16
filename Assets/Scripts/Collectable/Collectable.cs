using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class Collectable : MonoBehaviour
{
    [SerializeField]
    protected CollectableSO _collectableSO;
    private GameObject _collectable;
    private void Awake()
    {
        if (_collectableSO != null && transform.childCount == 0)
        {
            _collectable = Instantiate(_collectableSO.collectablePrefab, transform.position, Quaternion.identity, transform);
        }
    }
    // Handle the collection of the collectable through trigger collision
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            _collectableSO.Collect(other.GetComponent<Player>());
            Destroy(gameObject);
        }
    }
}
