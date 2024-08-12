using UnityEngine;

public class AudioPlayTest : MonoBehaviour
{
    public string[] playAudioNames;
    public string[] stopAudioNames;
    public string[]sfxOrVoiceNames;

    private int currentPlayIndex = 0;
    private int currentStopIndex = 0;

    void Start()
    {
         AudioManager.Instance.ListAllSounds();
    }

    public void PlayNextAudio()
    {
        if (playAudioNames.Length == 0)
        {
            Debug.LogWarning("No audio names set for playing.");
            return;
        }

        string audioToPlay = playAudioNames[currentPlayIndex];
        Debug.Log($"Attempting to play: {audioToPlay}");
        AudioManager.Instance.Play(audioToPlay);

        currentPlayIndex = (currentPlayIndex + 1) % playAudioNames.Length;
    }

    public void StopNextAudio()
    {
        if (stopAudioNames.Length == 0)
        {
            Debug.LogWarning("No audio names set for stopping.");
            return;
        }

        string audioToStop = stopAudioNames[currentStopIndex];
        Debug.Log($"Attempting to stop: {audioToStop}");
        AudioManager.Instance.Stop(audioToStop);

        currentStopIndex = (currentStopIndex + 1) % stopAudioNames.Length;
    }

    public void ToggleAudio(string audioName)
    {
        if (AudioManager.Instance.IsPlaying(audioName))
        {
            Debug.Log($"Stopping: {audioName}");
            AudioManager.Instance.Stop(audioName);
        }
        else
        {
            Debug.Log($"Playing: {audioName}");
            AudioManager.Instance.Play(audioName);
        }
    }

    public void PlayAllAudio()
    {
        foreach (string audioName in playAudioNames)
        {
            AudioManager.Instance.Play(audioName);
        }
    }

    public void StopAllAudio()
    {
        foreach (string audioName in stopAudioNames)
        {
            AudioManager.Instance.Stop(audioName);
        }
    }

    public void PlaySFXorVoice()
    {
         foreach (string audioName in sfxOrVoiceNames)
        {
            AudioManager.Instance.PlayOneShot(audioName);
        }
    }

    public void StopAll()
    {
        AudioManager.Instance.StopAll();
    }
}