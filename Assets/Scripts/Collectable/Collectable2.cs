using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class Collectable2 : MonoBehaviour
{
    public UnityEvent OnCollectableCollectedEvent;
    [SerializeField]
    protected CollectableSO _collectableSO;
    
    private void Awake()
    {
        Debug.Log("OnEnable");
        if (_collectableSO != null)
        {
            GameObject go = Instantiate(_collectableSO.collectablePrefab, transform.position, Quaternion.identity, transform);
        }
    }
    // Handle the collection of the collectable through trigger collision
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            OnCollectableCollectedEvent?.Invoke();
            PlaySoundEffect();
            Destroy(gameObject);
        }
    }

    protected virtual void PlaySoundEffect()
    {
        
    }
}
