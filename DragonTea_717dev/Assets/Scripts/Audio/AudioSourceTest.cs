using UnityEditor;
using UnityEngine;

public class AudioSourceTest : MonoBehaviour 
{
    public AudioSource audioSource;

    
    public void PlayAudio() {
        if (audioSource == null) return;
        audioSource.Stop();
        audioSource.Play();
    }


    [MenuItem("Test/PlayAudioTest")]
    public static void PlayAudioTestMenu()
    {
        var go = Selection.activeGameObject;
        if (go == null) return;
        var testComp = go.GetComponent<AudioSourceTest>();
        if (testComp == null) return;
        testComp.PlayAudio();
    }
}