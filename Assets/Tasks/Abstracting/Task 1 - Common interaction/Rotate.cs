using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour, IItemAction
{
    public Transform Target;

    public void RotateTarget(float amount)
    {
        Target.localEulerAngles += new Vector3(0, 0, amount * 360);
    }

    public void PerformAction(float amount)
    {
        RotateTarget(amount);
    }
}
