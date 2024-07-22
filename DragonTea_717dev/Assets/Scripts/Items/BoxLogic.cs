using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxLogic : ItemLogic
{
    public string AudioName;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollider(AudioName);
           // OnBoxCollision();
        }
       
    }
    private void OnCollisionExit2D(Collision2D other)
    {
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }
    override protected void OnCollider(string AudioName)
    {
        //AudioName=this.AudioName;
        AudioManager.instance.PlayOneShot(AudioName);
    }



   
   
}
