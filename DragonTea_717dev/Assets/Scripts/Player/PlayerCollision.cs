using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
   {
   
    /*if(other.gameObject.CompareTag("Timeline"))
    {
        EventHandler.CallTimelineOnCollision();
    }
    if(other.gameObject.CompareTag("Speak"))
    {
        EventHandler.CallSpeakerCollision(other.gameObject);
    }
    if(other.gameObject.CompareTag("Teleport"))
    {
        Debug.Log("daole");
        EventHandler.CallTransToAnotherSecne();
    }*/
   
   }

   private void OnTriggerExit2D(Collider2D other)
   {
    
   }
   
   private void OnCollisionEnter2D(Collision2D other)
   {

   }

   private void OnCollisionExit2D(Collision2D other)
   {

   }

}
