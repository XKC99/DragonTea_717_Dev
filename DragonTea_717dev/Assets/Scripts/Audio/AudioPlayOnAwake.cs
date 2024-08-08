using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayOnAwake : MonoBehaviour
{
   public string playName;
   public DialogueSpeaker startSpeaker;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        AudioManager.Instance.Play(playName);
        startSpeaker.Play();
    }

}
