using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// Used for the blur vision effect
public class FadeOut : MonoBehaviour
{
    private Tween _fadeTween;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
    }

    public void FadeOutObject(Color color, float duration)
    {
        if(_fadeTween != null)
        {
            _fadeTween.Kill();
        }

        _image.color = color;
        _image.enabled = true;
        _fadeTween = _image.DOFade(0, duration).OnComplete(() => {
            _image.enabled = false;
        });
    }
}
