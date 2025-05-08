using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPresenter : MonoBehaviour
{
    public TestObject Square;
    public TestObject Circle;
    public TestObject Triangle;
    public TestObject None;

    public List<TestObject> Presented = new();

    public void Present(IEnumerable<ObjectType> objects)
    {
        var list = objects.ToList();
        EnsureSize(list.Count);

        for (var i = 0; i < list.Count; i++)
        {
            var objectType = list[i];
            var obj = Presented[i];

            obj.Type = objectType;
            var prefab = GetPrefab(objectType);
            
            obj.Sync(prefab);
        }
    }

    private void EnsureSize(int amount)
    {
        var difference = Presented.Count - amount;

        for (int i = 0; i < Mathf.Abs(difference); i++)
        {
            if (difference < 0)
            {
                Presented.Add(Instantiate(GetPrefab(ObjectType.None), transform));
            }
            else
            {
                var last = Presented[^1];
                Presented.RemoveAt(Presented.Count - 1);
                Destroy(last.gameObject);
            }
        }
    }

    private TestObject GetPrefab(ObjectType objectType)
    {
        return objectType switch
        {
            ObjectType.Square => Square,
            ObjectType.Circle => Circle,
            ObjectType.Triangle => Triangle,
            ObjectType.None => None
        };
    }
}
