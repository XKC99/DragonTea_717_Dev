using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowPush : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlayOneShot("shua");
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  
    }

   
}
