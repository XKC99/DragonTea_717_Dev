using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxOnCollision : MonoBehaviour
{

    private void OnEnable()
    {
        EventHandler.BoxCollision +=OnBoxCollision;
        
    }
    private void OnDisable()
    {
        EventHandler.BoxCollision -=OnBoxCollision;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
             EventHandler.CallBoxOnCollision();
        }
       
    }
    private void OnBoxCollision()
    {
        //AudioManager.PlayOneShot("澤野弘之 - snow");
        AudioManager.instance.Play("123");    
        Debug.Log("BoxCollision");
    }
    
   
}
