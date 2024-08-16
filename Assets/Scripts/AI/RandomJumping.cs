using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

// This script is used to make an object jump to random positions
public class RandomJumping : Movement
{
    [SerializeField]
    private float _jumpHeight = 5;

    // Start is called before the first frame update
    void Start()
    {
        float z = transform.localPosition.z;
        Jump();
    }

    // Finds a random position to jump to
    private void Jump()
    {
        int randomX = Random.Range(-1, 2);
        int randomZ = Random.Range(-1, 2);
        float jumpHeight = _jumpHeight + Random.Range(-1, 2);
        transform.DOLocalJump(new Vector3(3 * randomX, 2, 3 * randomZ), jumpHeight, 1, _speed).SetEase(Ease.Linear).onComplete += () => Jump();
        transform.localRotation = Quaternion.Euler(0, Random.Range(0,361), 0);
    }
}
