using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CurrentTransPos : MonoBehaviour
{
    public Transform nextPos;
    public GameObject player;
    public CinemachineVirtualCamera cm;

    public UnityEvent TransPosEvent; 
    public void TransToNextPos()
    {
        cm.Follow = nextPos;
        player.transform.position = nextPos.position;
        cm.Follow = player.transform;
        OnTransPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TransToNextPos();
            OnTransPos();
        }
        else
        {
            collision.transform.position = nextPos.position;
        }
    }

    public void OnTransPos()
    {
        TransPosEvent?.Invoke();
    }



}
