using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Unity.VisualScripting;

// This script is used to create a magnetic power-up
public class Magnetic : PowerUpEffect
{
    private SphereCollider _sphereCollider;

    private void Start()
    {
        // Add sphere collider to player
        _sphereCollider = gameObject.AddComponent<SphereCollider>();
        _sphereCollider.radius = _effectRadius;
        _sphereCollider.isTrigger = true;
    }

    // When pellet enters sphere collider, move pellet towards player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pellet"))
        {
            other.gameObject.AddComponent<FollowTarget>().target = gameObject.transform;
        }
    }

    // When power-up is removed, remove sphere collider
    protected override void RemovePowerUp()
    {
        Destroy(_sphereCollider);
        base.RemovePowerUp();
    }
}
