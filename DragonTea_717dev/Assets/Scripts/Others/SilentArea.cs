using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SilentSpeaker();
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ActiveSpeaker();
        }
    }
    public void SilentSpeaker()
    {
        DataManager.Instance.isInSilentArea = true;
    }
    public void ActiveSpeaker()
    {
        DataManager.Instance.isInSilentArea = false;
    }
}
