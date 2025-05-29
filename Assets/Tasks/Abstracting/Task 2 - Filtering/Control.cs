using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Control : MonoBehaviour
{
    public ObjectPresenter Original;
    public ObjectPresenter Filtered;

    public ObjectRandomSequence Sequence;
    public DummyFilter Filter;

    public void Start()
    {
        Regenerate();
    }

    public void Regenerate()
    {
        List<ObjectType> objects = Sequence.Generate();
        Original.Present(objects);
        Filtered.Present(Filter.Filter(objects.ToList()));
    }
}
