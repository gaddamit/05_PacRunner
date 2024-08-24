using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : Collectable
{
    protected virtual void Awake()
    {
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            _collectableSO.Collect(other.GetComponent<Player>());
            gameObject.SetActive(false);
        }
    }
}
