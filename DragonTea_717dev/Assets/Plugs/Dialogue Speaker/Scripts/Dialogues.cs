using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class Dialogues
{
    [Tooltip("The actual AudioSource that will play")]
    public AudioClip clip;
    
    [Min(0), Tooltip("The amount of seconds before the audio plays")]
    public float time;

    [Tooltip("The subtitle to display")]
    public string subtitles;

    [Space(5), Tooltip("A method to trigger when this audio plays. Optional and can be left empty")]
    public UnityEvent triggerEvent;
}
