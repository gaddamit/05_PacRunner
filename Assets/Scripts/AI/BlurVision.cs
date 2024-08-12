using UnityEngine;
using DG.Tweening;

// This script is used to create a blur vision effect
public class BlurVision : MonoBehaviour
{
    [SerializeField]
    private float _blurDuration = 5.0f;
    [SerializeField]
    private Color _blurColor = new Color(0, 0, 0, 0.5f);
    private GameObject _blurVision;

    private void Awake()
    {
        // Find the blur vision object
        _blurVision = GameObject.Find("BlurVision");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            // Fade out the blur vision for a duration
            FadeOut fadeOut = _blurVision.GetComponent<FadeOut>();
            fadeOut.FadeOutObject(_blurColor, _blurDuration);

            Destroy(gameObject);
        }
    }
}
