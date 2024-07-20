using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName]public string SceneFrom;
    [SceneName]public string SceneTo;

/// <summary>
/// This function is called when the object becomes enabled and active.
/// </summary>
private void OnEnable()
{
    EventHandler.TransToAnotherSecne+=TeleportToScene;
}
/// <summary>
/// This function is called when the behaviour becomes disabled or inactive.
/// </summary>
private void OnDisable()
{
    EventHandler.TransToAnotherSecne-=TeleportToScene;
}
    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(SceneFrom, SceneTo);
    }

}
