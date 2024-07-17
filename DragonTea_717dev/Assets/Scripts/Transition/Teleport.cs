using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName]public string SceneFrom;
    [SceneName]public string SceneTo;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(SceneFrom, SceneTo);
    }

}
