using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanTooManyText : MonoBehaviour
{
public UnityEvent OnCleanEvent;

/// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
private void Update()
{
    CleanOverText();
}
   public void CleanOverText()
    {
        if(DataManager.Instance.cleanNumber >= 5)
        {
            AfterCleanText();
        }
    }

    public void AfterCleanText()
    {
        OnCleanEvent?.Invoke();
    }

    public void CleanLava()
    {
        DataManager.Instance.isDestroyeLava = true;

    }
}
