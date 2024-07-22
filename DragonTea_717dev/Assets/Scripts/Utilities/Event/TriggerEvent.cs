using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvent:BaseEvent
{
    public UnityEvent triggerBoxUnityEvent; 
    public UnityEvent triggerFireUnityEvent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))  //在这里可以考虑加入各种条件判断
        {
            OnTriggerPlayer();
        }
        if(other.CompareTag("Box"))
        {
            OnTriggerBox();
        }
    }

    private void OnTriggerBox()
    {
        Debug.Log($"Trigger触发:{gameObject.name}");
        triggerBoxUnityEvent?.Invoke();
    }

    private void OnTriggerFire()
    {

    }
    

    

}
