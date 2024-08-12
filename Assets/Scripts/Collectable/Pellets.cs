using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellets : Collectable
{
    public int score = 10;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            GameManager.Instance.IncreaseScore(score);
        }
    }
}
