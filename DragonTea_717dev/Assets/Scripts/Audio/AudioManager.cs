using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(0.1f, 3f)]
        public float pitch = 1f;
        public bool loop = false;

        [HideInInspector]
        public AudioSource source;
    }

    public Sound[] sounds;
    private Dictionary<string, Sound> soundDictionary = new Dictionary<string, Sound>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            soundDictionary[s.name] = s;
        }
    }

    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            if (s.source.isPlaying)
            {
                Debug.Log($"Sound {name} is already playing. Restarting.");
                s.source.Stop();
            }
            s.source.Play();
            Debug.Log($"Playing sound: {name}");
        }
        else
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
    }

    public void Stop(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            s.source.Stop();
            Debug.Log($"Stopping sound: {name}");
        }
        else
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
    }

    public void Pause(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            s.source.Pause();
            Debug.Log($"Pausing sound: {name}");
        }
        else
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
    }

    public void Resume(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            s.source.UnPause();
            Debug.Log($"Resuming sound: {name}");
        }
        else
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
    }

    public bool IsPlaying(string name)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            return s.source.isPlaying;
        }
        Debug.LogWarning($"Sound: {name} not found!");
        return false;
    }

    public void SetVolume(string name, float volume)
    {
        if (soundDictionary.TryGetValue(name, out Sound s))
        {
            s.source.volume = Mathf.Clamp01(volume);
            Debug.Log($"Set volume of {name} to {volume}");
        }
        else
        {
            Debug.LogWarning($"Sound: {name} not found!");
        }
    }

    public void ListAllSounds()
    {
        Debug.Log("All registered sounds:");
        foreach (var sound in soundDictionary)
        {
            Debug.Log($"Name: {sound.Key}, Clip: {sound.Value.clip.name}, IsPlaying: {sound.Value.source.isPlaying}");
        }
    }

   
}