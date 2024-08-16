using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "SOs/Collectable", order = 1)]
public class CollectableSO : ScriptableObject
{
    [SerializeField]
    private int _scoreValue = 10;
    public GameObject collectablePrefab;
    public AudioClip onCollectSound;
    
    private void Awake()
    {
    }

    public virtual void Collect(Player collector)
    {
        if(_scoreValue > 0)
        {
            GameManager.Instance.IncreaseScore(_scoreValue);
        }
        
        AudioManager.Instance.PlaySoundEffect(onCollectSound);
    }
}
