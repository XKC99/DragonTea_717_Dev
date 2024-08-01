using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class CustomClip : PlayableAsset, ITimelineClipAsset
{
    public CustomBehaviour template = new CustomBehaviour();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<CustomBehaviour>.Create(graph, template);
    }
}

