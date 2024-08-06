using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class NormalItem : MonoBehaviour
{
    
    public GameObject FNote;
    public bool playerIsInside;
    private void Update() 
    {
       
        if(Input.GetKeyDown(KeyCode.F)&&playerIsInside)
        {
            this.GetComponentInChildren<DialogueTreeController>().StartDialogue();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsInside = true;
            FNote.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsInside = false;
        FNote.SetActive(false);
        }
    }


}
