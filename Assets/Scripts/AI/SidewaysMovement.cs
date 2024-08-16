using UnityEngine;
using DG.Tweening;

// This script is used to make an object move sideways
public class SidewaysMovement : Movement
{
    [SerializeField]
    private bool _isMovingRight = true;
    [SerializeField]
    private float _xPosition = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Move the ghost sideways
        float z = transform.localPosition.z;
        transform.DOLocalMove(new Vector3(_isMovingRight ? _xPosition : -_xPosition, 2, z), _speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        
        InvokeRepeating("RotateGhost", 0, _speed);
    }

    // Face the ghost in the direction it is moving
    private void RotateGhost()
    {
        if (_isMovingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            _isMovingRight = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
            _isMovingRight = true;
        }
    }
}
