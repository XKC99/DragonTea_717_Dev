using UnityEngine;
using UnityEngine.Playables;

public class CustomMixerBehaviour : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Transform trackBinding = playerData as Transform;

        if (trackBinding == null)
            return;

        int inputCount = playable.GetInputCount();

        Vector3 blendedPosition = Vector3.zero;
        Vector3 blendedScale = Vector3.zero;
        float totalWeight = 0f;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<CustomBehaviour> inputPlayable = (ScriptPlayable<CustomBehaviour>)playable.GetInput(i);
            CustomBehaviour input = inputPlayable.GetBehaviour();

            blendedPosition += input.position * inputWeight;
            blendedScale += input.scale * inputWeight;
            totalWeight += inputWeight;
        }

        if (totalWeight > 0)
        {
            trackBinding.position = blendedPosition / totalWeight;
            trackBinding.localScale = blendedScale / totalWeight;
        }
    }
}

