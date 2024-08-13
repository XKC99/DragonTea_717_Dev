using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SilentSpeaker();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ActiveSpeaker();
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
