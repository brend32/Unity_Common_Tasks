using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class CountSquares_2 : MonoBehaviour
    {
        public Worker_2 Worker;
        public TextMeshProUGUI Output;
        public int Count;

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
            Count = 0;
            UpdateView();
        }

        public void UpdateView()
        {
            Output.text = $"Squares drawn: {Count}";
        }

        public void Reaction(List<ObjectType> objects)
        {
            Count += objects.Count(o => o == ObjectType.Square);
            UpdateView();
        }
    }
}
