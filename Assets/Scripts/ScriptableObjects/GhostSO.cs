using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public void InitializeColor(GameObject go)
    {
        Renderer renderer = go.GetComponent<Renderer>();
        Material[] mats = renderer.sharedMaterials;
        
        if(mats == null || mats.Length == 0)
        {
            return;
        }

        if(mats[1] == null)
        {
            mats[1] = new Material(material);
        }

        Material tempMaterial = new Material(mats[1]);
        if(tempMaterial != null)
        {
            tempMaterial.SetColor("_Color", color);
            tempMaterial.SetColor("_EmissionColor", color);
            mats[1] = tempMaterial;
            renderer.materials = mats;
        }
    }
}
