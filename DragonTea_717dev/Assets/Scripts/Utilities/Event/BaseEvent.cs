using UnityEngine;
using UnityEngine.Events;

public class BaseEvent : MonoBehaviour
{
    public UnityEvent triggerPlayerUnityEvent;  //玩家进入trigger区时触发的事件
  
    //public UnityEvent colliderUnityEvent;

    protected virtual void OnTriggerPlayer()
    {
        Debug.Log($"Trigger触发:{gameObject.name}");
        triggerPlayerUnityEvent?.Invoke();
    }

   
}