using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderTextOutput : MonoBehaviour
{
    public TextMeshProUGUI Output;

    private void Start()
    {
        var slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnValueChanged);
        OnValueChanged(slider.value);
    }

    private void OnValueChanged(float value)
    {
        Output.text = value.ToString(CultureInfo.InvariantCulture);
    }
}