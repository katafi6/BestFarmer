using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageTMP;

    private Slider _loadingSlider;

    private void Awake()
    {
        gameObject.SetActive(false);
        _loadingSlider = GetComponent<Slider>();
    }

    public void StartLoading()
    {
        gameObject.SetActive(true);
        PrintLoadingMessage(0f);
    }

    public void PrintLoadingMessage(float percent, string message = null)
    {
        _loadingSlider.value = percent;
        if (message == null)
        {
            messageTMP.text = "";
            return;
        }

        messageTMP.text = message;
    }
}