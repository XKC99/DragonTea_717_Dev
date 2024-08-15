using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TryToReturn : MonoBehaviour
{
    public int retrunTimes;
    public UnityEvent OnOverTimes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(retrunTimes>=3)
        {
            OnOverTimes?.Invoke();

        }
    }

    public void MarkReturnTimes()
    {
        retrunTimes++;
    }
}
