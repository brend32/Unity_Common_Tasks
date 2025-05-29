using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DummyFilter : MonoBehaviour
{
    public abstract List<ObjectType> Filter(List<ObjectType> objects);
}
