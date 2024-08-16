using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ghost", menuName = "SOs/Ghost")]
public class GhostSO : ScriptableObject
{
    [Range(0, 10)]
    public float movementTime;
    public float scale;
    public Color color;
    public Material material;
    public string movement;
    public string skill;
    public bool shouldDieOnCollision = true;
}
