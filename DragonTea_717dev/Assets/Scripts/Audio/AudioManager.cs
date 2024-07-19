using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("音乐数据库")]
    public SoundDetailList_SO soundDetailData;
    public SceneSoundList_SO sceneSoundData;
    
    [Header("Audio Source")]
    public AudioSource bgmSource;
    public AudioSource ambientSource; 

    
   
}
