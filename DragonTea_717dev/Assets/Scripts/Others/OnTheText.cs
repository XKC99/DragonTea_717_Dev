using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheText : MonoBehaviour
{
    public DialogueSpeaker onSpeaker;
   private void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.tag=="Player")
        {
            if(DataManager.Instance.isFirstOnText==true)
            {
                onSpeaker.Play();
                DataManager.Instance.isFirstOnText=false;
            }
        }
       
   }
}
