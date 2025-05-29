using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldScript : MonoBehaviour
{
    public TMP_InputField Field;
    public ItemScript Prefab;
    public Transform Container;

    private List<ItemScript> _objects = new List<ItemScript>();

    public void Add()
    {
        ItemScript instance = Instantiate(Prefab, Container);
        instance.Display(Field.text, _objects.Count);
        instance.OnDelete += DeleteItem;
        _objects.Add(instance);
    }

    public void DeleteItem(int index)
    {
        ItemScript obj = _objects[index];
        _objects.RemoveAt(index);
        
        Destroy(obj.gameObject);
        RearrangeIndicies();
    }

    public void RearrangeIndicies()
    {
        for (var i = 0; i < _objects.Count; i++)
        {
            ItemScript itemScript = _objects[i];
            itemScript.Display(itemScript.Value, i);
        }
    }
}
