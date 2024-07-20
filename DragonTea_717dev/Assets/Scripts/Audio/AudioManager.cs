using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  //设置为单例模式
    public AudioType[] AudioTypes;

    
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
         
         
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
       foreach (AudioType audioType in AudioTypes)
        {
            //audioType.Source = gameObject.AddComponent<AudioSource>();
            audioType.Source.clip = audioType.Clip;
            audioType.Source.name= audioType.Name;
            audioType.Source.loop = audioType.Loop;
            audioType.Source.pitch = audioType.Pitch;
            audioType.Source.volume = audioType.Volume;
            audioType.Source.playOnAwake = audioType.PlayOnAwake;
            if(audioType.MixerGroup!=null)
            {
                audioType.Source.outputAudioMixerGroup = audioType.MixerGroup;
            }
        }
    }
    

    public void Play(string name)
    {
        foreach(AudioType type in AudioTypes)
        {
            if(type.Name==name)
            {
                type.Source.Play();
                Debug.Log("播放"+name);
                return;
            }
        }
        Debug.Log("没有找到这个音频");
    }

    public void Pause(string name)
    {
        foreach(AudioType type in AudioTypes)
        {
            if(type.Name==name)
            {
                type.Source.Pause();
                return;
            }
        }
        Debug.Log("没有找到这个音频");
    }

    public void Stop(string name)
    {
        foreach(AudioType type in AudioTypes)
        {
            if(type.Name==name)
            {
                type.Source.Stop();
                return;
            }
        }
        Debug.Log("没有找到这个音频");
    }

    

   
}
