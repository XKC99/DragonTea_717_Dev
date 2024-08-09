using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class CustomBehaviour : PlayableBehaviour
{
    public Vector3 position;
    public Vector3 scale;
    public bool initialized = false;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    public override void OnGraphStart(Playable playable)
    {
        initialized = false;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Transform trackBinding = playerData as Transform;

        if (trackBinding == null)
            return;

        if (!initialized)
        {
            originalPosition = trackBinding.position;
            originalScale = trackBinding.localScale;
            initialized = true;
        }

        trackBinding.position = Vector3.Lerp(originalPosition, position, info.weight);
        trackBinding.localScale = Vector3.Lerp(originalScale, scale, info.weight);
    }

    public override void OnGraphStop(Playable playable)
    {
        initialized = false;
    }
}

