using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;

    public bool needSavePlayerPos;
    [SceneName]public string SceneFrom;
    [SceneName]public string SceneTo;
    
/// <summary>
/// This function is called when the object becomes enabled and active.
/// </summary>

    public void TeleportToScene()
    {
       
         TransitionManager.Instance.Transition(SceneFrom, SceneTo,player,needSavePlayerPos);
    }
    

}
