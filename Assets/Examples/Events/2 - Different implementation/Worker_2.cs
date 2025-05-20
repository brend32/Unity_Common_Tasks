using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Events
{
    public class Worker_2 : MonoBehaviour
    {
        public event Action<List<ObjectType>> OnObjectsDraw;

        public ObjectPresenter Presenter;
        public ObjectRandomSequence RandomSequence;
        
        public void Draw()
        {
            StartCoroutine(DrawingTask());
        }

        private IEnumerator DrawingTask()
        {
            for (int i = 0; i < 20; i++)
            {
                Presenter.Present(RandomSequence.Generate());
                yield return new WaitForSeconds(0.1f);
            }

            Presenter.Present(RandomSequence.Generate());
            OnObjectsDraw?.Invoke(RandomSequence.Sequence);
        }
    }
}
