using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverySecondFilter : DummyFilter
{
    public override List<ObjectType> Filter(List<ObjectType> objects)
    {
        List<ObjectType> result = new List<ObjectType>();
        
        for (int i = 0; i < objects.Count; i += 2)
        {
            result.Add(objects[i]);
        }
        
        return result; 
    }
}
