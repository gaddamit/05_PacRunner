using UnityEngine;
using DG.Tweening;

// This script is used to make an object move sideways
public class SidewaysMovement : MonoBehaviour
{
    [SerializeField]
    private bool isMovingRight = true;
    [SerializeField]
    private float _xPosition = 3;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private bool _shouldDieOnCollision = true;

    // Start is called before the first frame update
    void Start()
    {
        // Move the ghost sideways
        float z = transform.localPosition.z;
        transform.DOLocalMove(new Vector3(isMovingRight ? _xPosition : -_xPosition, 2, z), _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

        InvokeRepeating("RotateGhost", 0, _speed);
    }

    // Face the ghost in the direction it is moving
    private void RotateGhost()
    {
        if (isMovingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            isMovingRight = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            isMovingRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            Player player = other.GetComponent<Player>();
            if(_shouldDieOnCollision)
            {
                player?.OnDeath();
            }
        }
    }
}
