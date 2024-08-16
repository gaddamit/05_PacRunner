using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUpEffect
{
    private void Start()
    {
        // Add sphere collider to player
        Player player = GetComponent<Player>();
        player.IsInvincible = true;
    }

    protected override void InitializeVFX(GameObject visualEffect)
    {
        if(visualEffect != null)
        {
            _visualEffect = Instantiate(visualEffect, transform.position, Quaternion.identity);
            _visualEffect.transform.SetParent(transform);
            _visualEffect.transform.localPosition = new Vector3(0, 0.01f, 0);
            _visualEffect.transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
            _visualEffect.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected override void RemovePowerUp()
    {
        Player player = GetComponent<Player>();
        player.IsInvincible = false;
        base.RemovePowerUp();
    }
}
