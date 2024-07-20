using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvent:BaseEvent
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))  //在这里可以考虑加入各种条件判断
        {
            OnTrigger();
        }
        
    }

}
