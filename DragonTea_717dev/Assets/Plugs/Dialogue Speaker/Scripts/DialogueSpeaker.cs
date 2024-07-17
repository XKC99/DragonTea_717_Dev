using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class DialogueSpeaker : MonoBehaviour
{
    [Tooltip("The audio source used for the dialogue speaker")]
    public AudioSource centralAudio;

    [Tooltip("if set to true, this will play the dialogue on awake.")]
    public bool playOnAwake = false;

    [Tooltip("The text (TextMeshPro) you want for your subtitles.")]
    public TextMeshProUGUI subtitlesText;        

    [Tooltip("Set whether subtitles should appear with audio or not.")]
    public bool useSubtitles = true;       
    
    [Tooltip("Dialogue properties.")]
    public Dialogues[] dialogues;
    
    [Tooltip("Set whether you want to run an event when the dialogue finishes.")]
    public bool fireFinishEvent = false;
    
    [Tooltip("Set an event to run when the dialogue finishes. Optional and can be left empty.")]
    public UnityEvent finishedEvent;

    [Tooltip("Will hide the subtitles when an audio finishes and is waiting for the next one. This means the silent gap between each audio will have no subtitles if this is enabled.")]
    public bool hideSubtitlesOnDelay = true;

    [Tooltip("The subtitles will hide the moment the Dialogue Speaker component has played all of it's audios.")]
    public bool hideSubtitlesOnFinish = true;


    // current dialogue index
    public int index {
        get; 
        private set;
    }

    // flag if dialogue has been skipped
    bool instantSkip;

    // flag if dialogue has been started
    bool dialogueStarted;

    // flag that dialogue has been paused
    bool paused;

    // flag that subtitles need to be removed when a dialogue finishes
    bool tempRemoveSubtitles;

    // set to true when all the audios finish playing
    public bool isFinished {
        get;
        private set;
    }

    public bool isStarted {
        get;
        private set;
    }


    #region UNITY METHODS
    
    void Awake()
    {
        Reset();

        // set the central audio if not set
        if (centralAudio == null) {
            SetCentralAudio();
        }

        // play dialgoue if set to do so on awake
        if (playOnAwake) {
            Play();
        }
    }


    void Update()
    {
        if (!isFinished) {
            if (useSubtitles && !tempRemoveSubtitles) {
                if (dialogueStarted) subtitlesText.transform.gameObject.SetActive(true);
            }
            else {
                subtitlesText.transform.gameObject.SetActive(false);
            }
        }
    }


    void OnValidate()
    {
        SetCentralAudio();
    }


    void OnEnable()
    {
        SetCentralAudio();
    }

    #endregion
    

    #region SYSTEM METHODS

    // set the audio source used by dialogue speaker
    void SetCentralAudio()
    {
        centralAudio = GetComponent<AudioSource>();
    }

    
    // plays the current index dialogue and prints subtitles
    IEnumerator PlayDialogue()
    {
        isStarted = true;

        
        if (!instantSkip) {
            yield return new WaitForSeconds(dialogues[index].time);
        } 
        else {
            yield return new WaitForSeconds(0.15f);
        }

        
        PlayAudioClip(dialogues[index].clip);
        dialogues[index].triggerEvent.Invoke();
        
        isFinished = false;
        tempRemoveSubtitles = false;

        
        if (useSubtitles) {
            subtitlesText.transform.gameObject.SetActive(true);
        }
        else {
            subtitlesText.transform.gameObject.SetActive(false);
        }

        
        subtitlesText.text = dialogues[index].subtitles;
        instantSkip = false;
        
        
        StartCoroutine("CatchAudioEnds");
    }


    // get when audio finishes to play the next dialogue
    IEnumerator CatchAudioEnds()
    {
        yield return new WaitForSeconds(dialogues[index].clip.length - centralAudio.time);
        
        if (index + 1 < dialogues.Length) {
            index++;

            if (hideSubtitlesOnDelay) {
                tempRemoveSubtitles = true;
                subtitlesText.transform.gameObject.SetActive(false);
            }
            
            StartCoroutine("PlayDialogue");
        }
        else {
            FinishedDialogues();
        }
    }


    // play the passed audio clip
    void PlayAudioClip(AudioClip clip)
    {
        if (!paused) {
            centralAudio.Stop();
            centralAudio.clip = clip;
            centralAudio.Play();
            return;
        }


        centralAudio.Play();
        paused = false;
    }

    // all the dialogues have finished playing
    void FinishedDialogues()
    {
        Reset();
        tempRemoveSubtitles = true;
        
        if (fireFinishEvent) {
            finishedEvent.Invoke();
        }

        isFinished = true;
        if (hideSubtitlesOnFinish) subtitlesText.transform.gameObject.SetActive(false);
    }

    #endregion


    #region PUBLIC METHODS (APIS)
    
    // main public method that triggers the dialogues
    public void Play()
    {
        if (!dialogueStarted) {
            if (subtitlesText) subtitlesText.text = "";
            isFinished = false;
            dialogueStarted = true;
            StartCoroutine("PlayDialogue");
        }
    }
    
    
    // pause the current dialogue
    public void Pause()
    {
        paused = true;
        StopAllCoroutines();
        centralAudio.Pause();
    }


    // resume current dialogue
    public void Resume()
    {
        if (!paused) return;

        instantSkip = true;
        StartCoroutine("PlayDialogue");
    }


    // skip to next dialogue
    public void Skip()
    {
        if (!dialogueStarted || isFinished) return;

        StopAllCoroutines();

        centralAudio.Stop();
        paused = false;

        tempRemoveSubtitles = true;
        subtitlesText.transform.gameObject.SetActive(false);

        //if not last dialogue, increment and skip to next
        //if last, run the end method coroutine
        if ((index + 1) < dialogues.Length) {
            index++;
            instantSkip = true;
            StartCoroutine("PlayDialogue");
        }
        else {
            FinishedDialogues();
        }
    }


    // reset the dialogue speaker
    public void Reset()
    {
        dialogueStarted = false;
        index = 0;

        isFinished = false;
        paused = false;
        if (centralAudio) centralAudio.Stop();
    }


    // play the audio of passed index
    public void PlayAudioIndex(int audioIndex)
    {
        if (audioIndex > dialogues.Length - 1 || audioIndex < 0) {
            Debug.LogWarning("The passed index is out of range");
        }

        index = audioIndex;
        paused = false;

        StartCoroutine("PlayDialogue");
    }
    
    #endregion
}
