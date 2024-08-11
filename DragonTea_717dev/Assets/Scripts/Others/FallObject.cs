using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallObject : MonoBehaviour
{
    public UnityEvent OnPlayerDeath;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().PlayerIsDead();
            this.gameObject.SetActive(false);
            PlayerIsDeadEvent();
        }
    }

    public void PlayerIsDeadEvent()
    {
        OnPlayerDeath?.Invoke();
    }


}
