using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineLogic : MonoBehaviour
{
    
    private void OnEnable()
    {
        EventHandler.TimelineCollision += TimelineMeetPlayer;

    }
   
    private void OnDisable()
    {
        EventHandler.TimelineCollision -= TimelineMeetPlayer;
    }

    private void TimelineMeetPlayer()
    {
        this.GetComponent<PlayableDirector>().Play();
        //this.gameObject.SetActive(false); 不知道为什么这个不行
       this.OnDisable();
    }

    
}
