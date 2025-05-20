using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class Listener_1 : MonoBehaviour
    {
        public Worker_1 Worker;
        public TextMeshProUGUI Output;
        
        // Enemy - Health Worker
        //    - Notify health change
        // HealthBar - Update UI - Listener
        
        public void Subscribe()
        {
            Worker.OnNumberDraw += Reaction;
        }

        public void Unsubscribe()
        {
            Worker.OnNumberDraw -= Reaction;
        }

        public void Clear()
        {
            Output.text = "";
        }

        public void Reaction(int number)
        {
            Output.text += $"{number}\n";
        }
    }
}
