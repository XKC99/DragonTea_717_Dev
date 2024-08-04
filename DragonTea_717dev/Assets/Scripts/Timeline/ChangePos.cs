using System.Collections;
using System.Collections.Generic;
using ParadoxNotion;
using UnityEngine;

public class ChangePos : MonoBehaviour
{
    private Transform ResetPoint;
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag=="Player")
    //     {
    //         collision.gameObject.transform.position=ResetPoint.position;

    //         collision.gameObject.GetComponent<PlayerController>().RevivePos=ResetPoint;

    //         this.gameObject.SetActive(false);

    //     }

    // }
    private void Awake()
    {
        ResetPoint=this.transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerController>().ChangeReviePos(ResetPoint.position);
            this.gameObject.SetActive(false);
        }

    }

}
