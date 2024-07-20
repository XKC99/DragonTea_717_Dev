using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioType 
{
   public AudioSource Source;
   public AudioClip Clip;
   public AudioMixerGroup MixerGroup;

   public string Name;

   [Range(0f, 1.0f)]
   public float Volume=1.0f;
  [Range(0.1f, 5f)]
  public float Pitch;
   public bool Loop;

}
