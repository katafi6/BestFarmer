using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowFadeUI : MonoBehaviour
{
    private float _fadeTime = 1f;
    private Image _fadeImage;


    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeInOut()
    {
        if (_fadeImage.enabled == _fadeImage)
        {
            _fadeImage.enabled = true;
        }

        float elapsed = 0f;
        float startAlpha = 1f;
        float endAlpha = 0f;
        Color fadeColor = _fadeImage.color;

        while (elapsed < _fadeTime)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / _fadeTime);
            fadeColor.a = alpha;
            _fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = endAlpha;
        _fadeImage.color = fadeColor;
    }
}