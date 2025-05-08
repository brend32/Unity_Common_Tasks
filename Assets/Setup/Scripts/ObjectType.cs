using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public enum ObjectType
{
    Square,
    Circle,
    Triangle,
    
    None = 99
}

public static class ObjectTypeUtils
{
    public static List<TMP_Dropdown.OptionData> GetOptions()
    {
        return Enum.GetValues(typeof(ObjectType))
            .OfType<ObjectType>()
            .Where(o => o != ObjectType.None)
            .Select(o => new TMP_Dropdown.OptionData(o.ToString()))
            .ToList();
    }
}