using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "SOs/PowerUp", order = 1)]
public class PowerUpSO : CollectableSO, IPowerUp
{
    [SerializeField] protected float _duration = 5.0f;
    [SerializeField] protected float _effectRadius = 1.0f;
    [SerializeField] protected GameObject _visualEffect;
    [SerializeField] private string _powerUpName = "PowerUp";
    public override void Collect(Player collector)
    {
        base.Collect(collector);
        ApplyEffect(collector);
    }

    public void ApplyEffect(Player collector)
    {
        DynamicScriptAttacher attacher = collector.GetComponent<DynamicScriptAttacher>();
        if (attacher != null && collector != null)
        {
            PowerUpEffect[] powerUpEffects = collector.GetComponents<PowerUpEffect>();
            if(powerUpEffects.Any(x => x.GetType().Name == _powerUpName))
            {
                PowerUpEffect powerUpEffect = powerUpEffects.First(x => x.GetType().Name == _powerUpName);
                powerUpEffect.ResetDuration();
            }
            else
            {
                attacher.AttachScriptByName(collector.gameObject, _powerUpName);
                PowerUpEffect powerUpEffect = collector.GetComponents<PowerUpEffect>().First(x => x.GetType().Name == _powerUpName);
                powerUpEffect.Initialize(_duration, _effectRadius, _visualEffect);
            }
        }
        else
        {
            Debug.LogError("DynamicScriptAttacher or targetObject is not assigned.");
        }
    }
}
