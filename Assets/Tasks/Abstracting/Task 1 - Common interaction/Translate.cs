using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour, IItemAction
{
    public Transform Target;

    public void TranslateTarget(float amount)
    {
        Target.localPosition += Vector3.up * amount;
    }

    public void PerformAction(float amount)
    {
        TranslateTarget(amount);
    }
}
