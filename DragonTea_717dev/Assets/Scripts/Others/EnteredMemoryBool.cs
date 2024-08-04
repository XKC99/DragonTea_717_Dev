using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredMemoryBool : MonoBehaviour
{
    public void MarkEnteredMemory()
    {
        DataManager.Instance.isEneteredMemory = true;
    }
}
