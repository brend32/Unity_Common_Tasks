using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task4 : MonoBehaviour
{
    public bool[,] SlidingStripes(bool[,] map, int gap, int offset, int stripesAmount)
    {
        bool[,] result = new bool[map.GetLength(0), map.GetLength(1)];
        
        return result;
    }


    #region TASK_SETUP

    public ObjectPresenterGrid ActualPresenter;
    public ObjectPresenterGrid ExpectedPresenter;

    public Slider AmountX;
    public Slider AmountY;

    public Slider StripeSlideAmount;
    public Slider StripeGapAmount;
    public Slider StripesAmount;

    public Toggle ShowExpectedResult;

    public TextMeshProUGUI Result;

    private void Start()
    {
        AmountX.onValueChanged.AddListener(OnAmountChange);
        AmountY.onValueChanged.AddListener(OnAmountChange);
        StripeSlideAmount.onValueChanged.AddListener(OnAmountChange);
        StripeGapAmount.onValueChanged.AddListener(OnAmountChange);
        StripesAmount.onValueChanged.AddListener(OnAmountChange);
        ShowExpectedResult.onValueChanged.AddListener(o => UpdateState());
        UpdateState();
    }

    public void OnAmountChange(float amount)
    {
        UpdateState();
    }

    public void UpdateState()
    {
        ExpectedPresenter.gameObject.SetActive(ShowExpectedResult.isOn);

        var map = new bool[(int)AmountX.value, (int)AmountY.value];
        var offset = (int)StripeSlideAmount.value;
        var gap = (int)StripeGapAmount.value;
        var stripesAmount = (int)StripesAmount.value;
        
        var expected = Solution(map, gap, offset, stripesAmount);
        var actual = SlidingStripes(map, gap, offset, stripesAmount);

        var same = AreArraysEqual(expected, actual);

        Result.text = GetResultText(same);
        
        ActualPresenter.Present(Convert(actual, ObjectType.Square));
        ExpectedPresenter.Present(Convert(expected, ObjectType.Triangle));
    }

    public bool AreArraysEqual(bool[,] a, bool[,] b)
    {
        if (a.Length != b.Length)
            return false;

        for (int x = 0; x < a.GetLength(0); x++)
        {
            for (int y = 0; y < a.GetLength(1); y++)
            {
                if (a[x, y] != b[x, y])
                    return false;
            }
        }

        return true;
    }

    public ObjectType[,] Convert(bool[,] mask, ObjectType replace)
    {
        var result = new ObjectType[mask.GetLength(0), mask.GetLength(1)];
        
        for (int x = 0; x < mask.GetLength(0); x++)
        {
            for (int y = 0; y < mask.GetLength(1); y++)
            {
                result[x, y] = mask[x, y] ? replace : ObjectType.None;
            }
        }

        return result;
    }
    
    public bool[,] Solution(bool[,] map, int gap, int offset, int stripesAmount)
    {
        var result = new bool[map.GetLength(0), map.GetLength(1)];

        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                var xPos = x - y * offset;
                if (xPos < 0 || Mathf.Abs(xPos) / (gap + 1) >= stripesAmount)
                {
                    result[x, y] = false;
                    continue;
                }
                
                result[x, y] = xPos % (gap + 1) == 0;
            }
        }

        return result;
    }

    public string GetResultText(bool pass)
    {
        return pass ? "<color=green>PASS</color>" : "<color=red>FAIL</color>";
    }
    #endregion
}
