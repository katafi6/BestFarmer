using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Transform _arrivalTr;

    [SerializeField] private CinemachineConfiner2D _confiner;
    [SerializeField] private PolygonCollider2D _arrivalColldier;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((_layerMask.value & (1 << other.gameObject.layer)) == 0)
            return;

        if (_confiner == null)
            return;

        other.transform.position = _arrivalTr.position;
        _confiner.m_BoundingShape2D = _arrivalColldier;
        _confiner.InvalidateCache();
    }
}