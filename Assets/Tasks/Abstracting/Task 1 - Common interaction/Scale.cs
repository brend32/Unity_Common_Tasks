using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour, IItemAction
{
    public Transform Target;
    
    public void ScaleTarget(float amount)
    {
        Target.localScale += new Vector3(amount, amount, amount);
    }

    public void PerformAction(float amount)
    {
        ScaleTarget(amount);
    }
}
