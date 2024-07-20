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
    override protected void OnCollider(string AudioName)
    {
        //AudioName=this.AudioName;
        AudioManager.instance.PlayOneShot(AudioName);
    }


    /*
    private void OnBoxCollision()
    {
        //AudioManager.PlayOneShot("澤野弘之 - snow");
        AudioManager.instance.Play("123");    
        Debug.Log("BoxCollision");
    }
    */
   
}
