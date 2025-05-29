using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First4Filter : DummyFilter
{
    public override List<ObjectType> Filter(List<ObjectType> objects)
    {
        List<ObjectType> result = new List<ObjectType>();
        
        for (int i = 0; i < 4; i++)
        {
            result.Add(objects[i]);
        }
        
        return result;
    }
}
