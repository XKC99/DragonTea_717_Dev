using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeLine;

    public void PlayTimeline()
    {
        timeLine.Play();
        this.gameObject.SetActive(false);
    }
}
