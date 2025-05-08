using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task3 : MonoBehaviour
{
    public bool SpotSequence(List<TestObject> testObjects, List<ObjectType> sequence)
    {
        return false;
    }


    #region TASK_SETUP

    public ObjectRandomSequence SequenceGenerator;
    public ObjectPresenter Presenter;

    public TMP_Dropdown[] Dropdowns;
    public Slider AmountSlider;

    public TextMeshProUGUI Expected;
    public TextMeshProUGUI Actual;
    public TextMeshProUGUI Amount;

    public int DisplayAmount;
    public List<ObjectType> Sequence = new();

    private void Start()
    {
        int i = 0;
        foreach (var dropdown in Dropdowns)
        {
            int index = i;
            dropdown.options = ObjectTypeUtils.GetOptions(); 
            dropdown.onValueChanged.AddListener(di =>
            {
                Sequence[index] = (ObjectType)di;
                UpdateState();
            });
            dropdown.value = 0;
            Sequence.Add((ObjectType)dropdown.value);
            i++;
        }

        DisplayAmount = (int)AmountSlider.value;
        AmountSlider.onValueChanged.AddListener(OnAmountChange);
        
        GenerateNewValue();
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
        Actual.text = GetResultText(SpotSequence(objs, Sequence));
        Expected.text = GetResultText(Solution(objs, Sequence));
    }

    public void GenerateNewValue()
    {
        Presenter.Present(SequenceGenerator.Generate());
        UpdateState();
    }

    public bool Solution(List<TestObject> testObjects, List<ObjectType> sequence)
    {
        for (int i = 0; i < testObjects.Count - sequence.Count + 1; i++)
        {
            bool fail = false;
            for (int j = 0; j < sequence.Count; j++)
            {
                if (testObjects[i + j].Type != sequence[j])
                {
                    fail = true;
                    break;
                }
            }

            if (fail == false)
                return true;
        }

        return false;
    }

    public string GetResultText(bool pass)
    {
        return pass ? "<color=green>PASS</color>" : "<color=red>FAIL</color>";
    }
    #endregion
}
