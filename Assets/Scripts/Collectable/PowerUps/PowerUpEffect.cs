using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    [SerializeField] protected float _duration = 5.0f;
    [SerializeField] protected float _effectRadius = 1.0f;
    [SerializeField] protected GameObject _visualEffect;

    public void Initialize(float duration, float sphereRadius, GameObject visualEffect)
    {
        this._duration = duration;
        this._effectRadius = sphereRadius;
        InitializeVFX(visualEffect);

        Invoke("RemovePowerUp", _duration);
    }

    protected virtual void InitializeVFX(GameObject visualEffect)
    {
        if(visualEffect != null)
        {
            _visualEffect = Instantiate(visualEffect, transform.position, Quaternion.identity);
            _visualEffect.transform.SetParent(transform);
            _visualEffect.transform.localPosition = new Vector3(0, 0.01f, 0);
            _visualEffect.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            _visualEffect.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // If the player picks up the same power-up again, reset the duration
    public virtual void ResetDuration()
    {
        CancelInvoke("RemovePowerUp");
        Invoke("RemovePowerUp", _duration);
    }

    protected virtual void RemovePowerUp()
    {
        if(_visualEffect != null)
        {
            Destroy(_visualEffect);
        }
        Destroy(this);
    }
}
