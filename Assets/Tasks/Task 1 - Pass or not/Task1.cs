using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task1 : MonoBehaviour
{
    public bool PassOrNot(TestObject testObject, ObjectType allowedType)
    {
        return false;
    }


    #region TASK_SETUP

    public ObjectRandomSequence SequenceGenerator;
    public ObjectPresenter Presenter;

    public ObjectType AllowedType;
    public TMP_Dropdown Dropdown;

    public TextMeshProUGUI Expected;
    public TextMeshProUGUI Actual;

    private void Start()
    {
        Dropdown.options = ObjectTypeUtils.GetOptions(); 
        Dropdown.onValueChanged.AddListener(OnTypeChanged);
        GenerateNewValue();
        Dropdown.value = 0;
    }

    public void OnTypeChanged(int index)
    {
        AllowedType = (ObjectType)index;
        UpdateState();
    }

    public void UpdateState()
    {
        var obj = Presenter.Presented[0];
        Actual.text = GetResultText(PassOrNot(obj, AllowedType));
        Expected.text = GetResultText(Solution(obj, AllowedType));
    }

    public void GenerateNewValue()
    {
        Presenter.Present(SequenceGenerator.Generate());
        UpdateState();
    }

    public bool Solution(TestObject testObject, ObjectType allowedType)
    {
        return testObject.Type == allowedType;
    }

    public string GetResultText(bool pass)
    {
        return pass ? "<color=green>PASS</color>" : "<color=red>FAIL</color>";
    }
    #endregion
}
