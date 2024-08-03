using UnityEngine;
using UnityEngine.Playables;

public class ControlRigidbodyPhysics : MonoBehaviour
{
    public PlayableDirector director;
    public Rigidbody2D playerRigidbody;

    void Start()
    {
        director.played += OnTimelinePlayed;
        director.stopped += OnTimelineStopped;
    }

    void OnTimelinePlayed(PlayableDirector pd)
    {
        if (pd == director)
        {
            // 禁用物理引擎控制
            playerRigidbody.isKinematic = true;
        }
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        if (pd == director)
        {
            // 恢复物理引擎控制
            playerRigidbody.isKinematic = false;
        }
    }
}
