using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerLogic : MonoBehaviour
{
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        EventHandler.SpeakerCollision+=OnMeetPlayer;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        EventHandler.SpeakerCollision-=OnMeetPlayer;
    }

    private void OnMeetPlayer()
    {
        this.GetComponent<DialogueSpeaker>().Play();
        OnDisable();
    }
}
