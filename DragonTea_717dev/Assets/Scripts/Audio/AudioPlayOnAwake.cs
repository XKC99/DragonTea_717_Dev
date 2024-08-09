using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayOnAwake : MonoBehaviour
{
   public string playName;
   public DialogueSpeaker startSpeaker;

    private void Start()
    {
        AudioManager.Instance.Play(playName);
        startSpeaker.Play();
    }
   

}
