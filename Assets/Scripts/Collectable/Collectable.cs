using DG.Tweening;
using UnityEngine;

[ExecuteInEditMode]
public class Collectable : MonoBehaviour
{
    private GameObject _collectable;
    [SerializeField]
    protected CollectableSO _collectableSO;
    [SerializeField] private bool _shouldAnimate = false;
    private void Awake()
    {
        if (_collectableSO != null && transform.childCount == 0)
        {
            _collectable = Instantiate(_collectableSO.collectablePrefab, transform.position, Quaternion.identity, transform);
        }
    }

    private void Start()
    {
        if(_shouldAnimate)
        {
            transform.DOLocalMoveY(3f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }

    // Handle the collection of the collectable through trigger collision
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            _collectableSO.Collect(other.GetComponent<Player>());
            Destroy(gameObject);
        }
    }
}
