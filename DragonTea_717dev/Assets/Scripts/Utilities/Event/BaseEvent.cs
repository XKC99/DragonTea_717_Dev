using UnityEngine;
using UnityEngine.Events;

public class BaseEvent : MonoBehaviour
{
    public UnityEvent triggerUnityEvent;
    //public UnityEvent colliderUnityEvent;


    protected virtual void OnTrigger()
    {
        Debug.Log($"Trigger触发:{gameObject.name}");
        triggerUnityEvent?.Invoke();
    }

    /*protected virtual void OnCollider()
    {
        Debug.Log($"Collider触发:{gameObject.name}");
        colliderUnityEvent?.Invoke();
    }*/

}