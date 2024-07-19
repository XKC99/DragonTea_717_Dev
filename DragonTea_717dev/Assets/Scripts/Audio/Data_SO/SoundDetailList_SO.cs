using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDetailList_SO", menuName = "Sound/SoundDetailList")]
public class SoundDetailList_SO: ScriptableObject
{
    public List<SoundDetail> soundDetailsList;
    public SoundDetail GetSoundDetail(SoundName name)
    {
        return soundDetailsList.Find(s=>s.soundName == name);
    }
   
}
[System.Serializable]
public class SoundDetail
{
    public SoundName soundName;
    public AudioClip soundClip;
    public float soundVolume;
    public float soundPitch;
}