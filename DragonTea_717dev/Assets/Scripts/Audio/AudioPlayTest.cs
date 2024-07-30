using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayTest : MonoBehaviour
{
    public string thePlayAudioName;
    public string theStopAudioName;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioManager.instance.Stop(theStopAudioName);
            if(theStopAudioName==null)
            {
                return;
            }
            AudioManager.instance.Play(thePlayAudioName);
            Debug.Log("放音乐");
            this.gameObject.SetActive(false);
            
        }
    }

    
}
