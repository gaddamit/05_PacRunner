using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public UnityEvent OnCollectableCollectedEvent;
    [SerializeField] private AudioClip collectableSound;

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
        AudioManager.Instance.PlaySoundEffect(collectableSound);
    }
}
