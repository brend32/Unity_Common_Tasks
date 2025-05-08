using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task2 : MonoBehaviour
{
    public bool AnyAllowed(List<TestObject> testObjects, ObjectType allowedType)
    {
        return false;
    }


    #region TASK_SETUP

    public ObjectRandomSequence SequenceGenerator;
    public ObjectPresenter Presenter;

    public ObjectType AllowedType;
    public TMP_Dropdown Dropdown;
    public Slider AmountSlider;

    public TextMeshProUGUI Expected;
    public TextMeshProUGUI Actual;
    public TextMeshProUGUI Amount;

    public int DisplayAmount;

    private void Start()
    {
        Dropdown.options = ObjectTypeUtils.GetOptions(); 
        DisplayAmount = (int)AmountSlider.value;
        Dropdown.onValueChanged.AddListener(OnTypeChanged);
        AmountSlider.onValueChanged.AddListener(OnAmountChange);
        
        GenerateNewValue();
        Dropdown.value = 0;
    }

    public void OnTypeChanged(int index)
    {
        AllowedType = (ObjectType)index;
        UpdateState();
    }

    public void OnAmountChange(float amount)
    {
        DisplayAmount = (int)amount;
        UpdateState();
    }

    public void UpdateState()
    {
        Amount.text = DisplayAmount.ToString();
        Presenter.Present(SequenceGenerator.Sequence.Take(DisplayAmount));
        var objs = Presenter.Presented;
        Actual.text = GetResultText(AnyAllowed(objs, AllowedType));
        Expected.text = GetResultText(Solution(objs, AllowedType));
    }

    public void GenerateNewValue()
    {
        Presenter.Present(SequenceGenerator.Generate());
        UpdateState();
    }

    public bool Solution(List<TestObject> testObjects, ObjectType allowedType)
    {
        return testObjects.Any(o => o.Type == allowedType);
    }

    public string GetResultText(bool pass)
    {
        return pass ? "<color=green>PASS</color>" : "<color=red>FAIL</color>";
    }
    #endregion
}
