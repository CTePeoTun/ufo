using UnityEngine;

public class DebugLog
{
    public static void ShowAllFieldsOnClass(object obj, string header = "")
    {
        
        string log = string.IsNullOrEmpty(header) ? "" : header + "\n";
        foreach (var property in obj.GetType().GetProperties())
        {
            log += string.Format("{0} is {1}\n", property.Name, property.GetValue(obj));
        }
        Debug.Log(log);
    }

}
