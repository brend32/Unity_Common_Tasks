using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TestObject : MonoBehaviour
{
    public ObjectType Type;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Sync(TestObject prefab)
    {
        Start();
        prefab.Start();
        _image.color = prefab._image.color;
        _image.sprite = prefab._image.sprite;
    }
}