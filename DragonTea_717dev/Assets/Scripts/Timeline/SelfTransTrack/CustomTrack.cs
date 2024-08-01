using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(CustomClip))]
[TrackBindingType(typeof(Transform))]
public class CustomTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<CustomMixerBehaviour>.Create(graph, inputCount);
    }

    public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
    {
        base.GatherProperties(director, driver);

        Transform trackBinding = director.GetGenericBinding(this) as Transform;
        if (trackBinding == null)
            return;

        foreach (var clip in GetClips())
        {
            var customClip = (CustomClip)clip.asset;
            if (customClip.template.initialized == false)
            {
                customClip.template.position = trackBinding.position;
                customClip.template.scale = trackBinding.localScale;
                customClip.template.initialized = true;
            }
        }
    }
}

