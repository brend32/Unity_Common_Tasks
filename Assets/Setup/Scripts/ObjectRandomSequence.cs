using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomSequence : MonoBehaviour
{
    public List<ObjectType> Sequence = new();

    public int Amount = 10;

    public List<ObjectType> Generate()
    {
        Sequence = new List<ObjectType>();

        for (int i = 0; i < Amount; i++)
        {
            Sequence.Add((ObjectType)Random.Range(0, 3));
        }

        return Sequence;
    }
}