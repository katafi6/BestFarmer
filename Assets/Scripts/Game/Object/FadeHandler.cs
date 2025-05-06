using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private string _triggerTag;

    private Color _baseColor;
    private Color _targetColor;

    private void Awake()
    {
        _triggerTag = "Player";
        _baseColor = _renderer.color;
        _targetColor = _renderer.color;
        _targetColor.a = 0.5f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
      

        if (other.CompareTag(_triggerTag))
        {
            _renderer.color = _targetColor;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_triggerTag))
        {
            _renderer.color = _baseColor;
        }
    }
}