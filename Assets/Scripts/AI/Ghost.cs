using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class Ghost : MonoBehaviour
{
    [SerializeField] private GhostSO _ghostSO;
    private void Awake()
    {
        InitializeMovement();
        InitializeSkill();
    }

    protected virtual void InitializeMovement()
    {
        DynamicScriptAttacher attacher = gameObject.GetComponent<DynamicScriptAttacher>();
        if(attacher != null)
        {
            if(!string.IsNullOrEmpty(_ghostSO.movement))
            {
                attacher.AttachScriptByName(gameObject, _ghostSO.movement);
                Movement movement = gameObject.GetComponent<Movement>();
                if(movement != null)
                {
                    movement.Initialize(_ghostSO.movementTime);
                }
            }
        }
    }
    
    protected virtual void InitializeSkill()
    {
        DynamicScriptAttacher attacher = gameObject.GetComponent<DynamicScriptAttacher>();
        if(attacher != null)
        {
            if(!string.IsNullOrEmpty(_ghostSO.skill))
            {
                attacher.AttachScriptByName(gameObject, _ghostSO.skill);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            Player player = other.GetComponent<Player>();
            if(_ghostSO.shouldDieOnCollision)
            {
                player?.OnDeath();
            }
        }
    }
}
