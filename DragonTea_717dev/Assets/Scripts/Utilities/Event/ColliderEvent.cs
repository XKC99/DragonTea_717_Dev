using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ColliderEvent : BaseEvent
{
     public UnityEvent ColliderEventPlayer; 
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            //OnCollider();
            OnColliderPlayer();
        }

     
    }

    public void OnColliderPlayer()
    {
        Debug.Log($"Collider触发:{gameObject.name}");
        ColliderEventPlayer?.Invoke();
    }
}
