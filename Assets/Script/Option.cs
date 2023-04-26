using System.Collections.Generic;
using UnityEngine;

public class Option
{
    public string name;
    public string stringValue;
    public int value;

    public static int OptionInt(string name, OptionList optionList)
    {
        object element = null;

        if(optionList.dataList.TryGetValue(name, out object value))
        {
            element = value;
        }
        else
        {
            Debug.LogWarning("Key not found");
        }

        if (element != null)
        {
            return ((Option)element).value;
        }

        Debug.LogWarning(string.Format("option_int: option named %s not found\nMaybe you should delete the .bygfoot directory from your home dir", name));

        return -1;
    }
}

public class OptionList
{
    public List<object> list;
    public Dictionary<string, object> dataList;
}
