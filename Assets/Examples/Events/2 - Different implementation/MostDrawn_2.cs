using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class MostDrawn_2 : MonoBehaviour
    {
        public Worker_2 Worker;
        public TextMeshProUGUI Output;
        public Dictionary<ObjectType, int> Count = new();

        public void Start()
        {
            Subscribe();
        }

        public void Subscribe()
        {
            Worker.OnObjectsDraw += Reaction;
        }

        public void Unsubscribe()
        {
            Worker.OnObjectsDraw -= Reaction;
        }

        public void Clear()
        {
            Count.Clear();
            UpdateView();
        }

        public void UpdateView()
        {
            if (Count.Count == 0)
            {
                Output.text = "No data :(";
                return;
            }
            
            ObjectType max = Count.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
            
            Output.text = $"Most drawn are: {max}";
        }

        public void Reaction(List<ObjectType> objects)
        {
            foreach (var objectType in objects)
            {
                if (Count.TryAdd(objectType, 1) == false)
                {
                    Count[objectType]++;
                }
            }
            UpdateView();
        }
    }
}
