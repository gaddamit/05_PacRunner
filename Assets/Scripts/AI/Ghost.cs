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
        if (_ghostSO != null)
        {
            InitializeColor();
            InitializeMovement();
            InitializeSkill();
        }
    }
    
    protected virtual void InitializeColor()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if(renderer != null)
        {
            List<Material> mat = GetComponent<Renderer>().materials.ToList();
            mat[1].SetColor("_Color", _ghostSO.color);
            mat[1].SetColor("_EmissionColor", _ghostSO.color);

            mat[2].SetColor("_Color", Color.black);
            mat[3].SetColor("_Color", Color.black);
            mat[1].SetFloat("_Metallic", 0.5f);
            mat[1].SetFloat("_Glossiness", 0.7f);
        }
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
            Debug.Log("Player collided with ghost");
            Player player = other.GetComponent<Player>();
            if(_ghostSO.shouldDieOnCollision)
            {
                player?.OnDeath();
            }
        }
    }
}
