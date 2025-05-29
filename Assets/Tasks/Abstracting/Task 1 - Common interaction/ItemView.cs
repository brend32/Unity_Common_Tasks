using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public GameObject Self;
    public float Amount = 0.3f;

    public void PerformAction()
    {
        Self.GetComponent<IItemAction>().PerformAction(Amount);
    }
    
    #region TASK_SETUP
    public Image Selection;
    
    public void SetSelection(bool selected)
    {
        Selection.color = selected ? Color.green : Color.white;
    }
    #endregion
}
