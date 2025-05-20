using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class Worker_1 : MonoBehaviour
    {
        // OnNumberDraw 
        //  - Reaction - Update UI 
        public event Action<int> OnNumberDraw;

        public TextMeshProUGUI Output;
        
        public void DrawNumber()
        {
            StartCoroutine(NumberDrawingTask());
        }

        private IEnumerator NumberDrawingTask()
        {
            for (int i = 0; i < 20; i++)
            {
                Output.text = Random.Range(0, 100).ToString();
                yield return new WaitForSeconds(0.1f);
            }

            int number = Random.Range(0, 100);
            Output.text = $"Your number is: \n{number}";
            
            OnNumberDraw?.Invoke(number);
        }
    }
}
