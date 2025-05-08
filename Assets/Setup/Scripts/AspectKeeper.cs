using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class AspectKeeper : MonoBehaviour
{
    private LayoutElement _layoutElement;
    private RectTransform _rectTransform;

    private void Start()
    {
        _layoutElement = GetComponent<LayoutElement>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _layoutElement.preferredWidth = _rectTransform.rect.height;
    }
}