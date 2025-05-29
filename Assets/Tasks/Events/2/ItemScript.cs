using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public TextMeshProUGUI Content;
    public int Index;
    public string Value;

    public event Action<int> OnDelete;

    public void Display(string value, int index)
    {
        Content.text = $"[{index}] {value}";
        Value = value;
        Index = index;
    }

    public void Delete()
    {
       OnDelete?.Invoke(Index);
    }
}
