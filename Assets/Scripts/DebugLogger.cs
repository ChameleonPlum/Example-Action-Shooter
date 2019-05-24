using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebugLogger
{
    public void Log(object sender, string message)
    {
        Debug.Log("Sender: " + sender.GetType().Name + ", Message: " + message);
    }

    public void LogWarning(object sender, string message)
    {
        Debug.LogWarning("Sender: " + sender.GetType().Name + ", Message: " + message);
    }

    public void LogError(object sender, string message)
    {
        Debug.LogError("Sender: " + sender.GetType().Name + ", Message: " + message);
    }
}
