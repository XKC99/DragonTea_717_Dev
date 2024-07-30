using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialTriggerEvent : MonoBehaviour
{
    public UnityEvent specialTriggerEvent;



    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                if(DataManager.Instance.isPlayerDead==false&&(other.gameObject.GetComponent<PhysicsCheck>().LastVelocity.y>=other.gameObject.GetComponent<PlayerController>().jumpDeadSpeed))
                {
                    Debug.Log("我还没死");
                    specialTriggerEvent?.Invoke();
                }
                break;
        }
    }
}
