using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

// This script is used to create a magnetic power-up
public class Magnetic : MonoBehaviour
{
    private float _duration;
    private float _sphereRadius;
    private SphereCollider _sphereCollider;
    public void Initialize(float duration, float sphereRadius)
    {
        this._duration = duration;
        this._sphereRadius = sphereRadius;
    }

    private void Start()
    {
        // Add sphere collider to player
        _sphereCollider = gameObject.AddComponent<SphereCollider>();
        _sphereCollider.radius = _sphereRadius;
        _sphereCollider.isTrigger = true;
        
        Invoke("RemoveMagnetic", _duration);
    }

    // When pellet enters sphere collider, move pellet towards player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pellet"))
        {
            other.gameObject.AddComponent<FollowTarget>().target = gameObject.transform;
        }
    }

    // If the player picks up another magnet, reset the duration
    public void ResetDuration()
    {
        CancelInvoke("RemoveMagnetic");
        Invoke("RemoveMagnetic", _duration);
    }

    // Remove the magnetic power-up
    private void RemoveMagnetic()
    {
        Destroy(_sphereCollider);
        Destroy(this);
    }
}
