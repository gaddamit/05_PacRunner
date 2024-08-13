using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "CollectableSO", order = 1)]
public class CollectableSO : ScriptableObject
{
    public GameObject collectablePrefab;
    public AudioClip onCollectSound;
    
    private void Awake()
    {
    }
}
