using UnityEngine;
using DG.Tweening;

// Used by the Magnet power-up to make the object follow the player
public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 60.0f;
    public void Update()
    {
        // Move this object towards the target
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y += 2.0f;

            float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
