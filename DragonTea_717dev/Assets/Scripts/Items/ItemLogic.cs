using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour
{
    protected virtual void OnCollider(string AudioName)
    {
        AudioManager.instance.Play(AudioName);
    }
   
}
