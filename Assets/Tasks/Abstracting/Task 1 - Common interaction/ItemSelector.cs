using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSelector : MonoBehaviour
{
    public ItemView[] Items;

    public void Start()
    {
        Items = FindObjectsByType<ItemView>(FindObjectsSortMode.None);
    }

    public void SelectRandom()
    {
        StartCoroutine(SelectTask());
    }

    public IEnumerator SelectTask()
    {
        for (int i = 0; i < 20; i++)
        {
            SetSelection(i % Items.Length);
            yield return new WaitForSeconds(0.1f);
        }

        int randomItem = Random.Range(0, Items.Length);
        Debug.Log($"Selected: {randomItem}");
        SetSelection(randomItem);
        Items[randomItem].PerformAction();
    }

    public void SetSelection(int i)
    {
        for (int j = 0; j < Items.Length; j++)
        {
            Items[j].SetSelection(i == j);
        }
    }
}

