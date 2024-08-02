using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayTest : MonoBehaviour
{
    // public List<string> thePlayAudioName;
    // public List<string> theStopAudioName;
    public string thePlayAudioName;
    public string theStopAudioName;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // AudioManager.instance.Stop(theStopAudioName);
            // if(theStopAudioName==null)
            // {
            //     return;
            // }
            AudioManager.instance.Play(thePlayAudioName);
            Debug.Log("放音乐");
            // this.gameObject.SetActive(false);
            
        }
    }

    // public void PlayerTheCLip()
    // {
    //     for(int i=0;i<thePlayAudioName.Count;i++)
    //     {
    //         AudioManager.instance.Play(thePlayAudioName[i]);
    //     }
      
    // }

    // public void StopTheCLip()
    // {
    //     for(int i=0;i<theStopAudioName.Count;i++)
    //     {
    //         AudioManager.instance.Stop(theStopAudioName[i]);
    //     }
      
    // }

    
}
