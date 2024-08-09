using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private DialogueSpeaker currentSpeaker;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDialogue(DialogueSpeaker speaker)
    {
        if (currentSpeaker != null && currentSpeaker != speaker)
        {
            currentSpeaker.Interrupt();
        }
        currentSpeaker = speaker;
    }

    public void ClearCurrentSpeaker(DialogueSpeaker speaker)
    {
        if (currentSpeaker == speaker)
        {
            currentSpeaker = null;
        }
    }
}
