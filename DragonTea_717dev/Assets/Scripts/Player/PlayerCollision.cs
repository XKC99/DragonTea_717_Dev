using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private GameObject FNote;//靠近NPC显示的提示UI
    public DialogueTreeController npcDialogueTreeController;  //NPC身上的DialogueTreeController组件

    private void OnTriggerEnter2D(Collider2D other)
    {
    if(other.gameObject.CompareTag("NPC"))
    {
        FNote=other.transform.Find("Canvas").gameObject;
        npcDialogueTreeController=other.GetComponentInChildren<DialogueTreeController>();
        Debug.Log("F显示");
        FNote.SetActive(true);
    }
   
    if(other.gameObject.CompareTag("Timeline"))
    {
       
    }
    if(other.gameObject.CompareTag("Speak"))
    {
       
    }
    if(other.gameObject.CompareTag("Teleport"))
    {
        
    }
   
   }

   private void OnTriggerExit2D(Collider2D other)
   {
    if(other.gameObject.CompareTag("NPC"))
    {
        var npc=other.gameObject.GetComponentInChildren<DialogueTreeController>();
            if(npcDialogueTreeController== npc)
            {
                npcDialogueTreeController = null;
            }
        Debug.Log("F隐藏");
        FNote.SetActive(false);
    }

   }
   
   private void OnCollisionEnter2D(Collision2D other)
   {

   }

   private void OnCollisionExit2D(Collision2D other)
   {

   }

   public void FNoteDisable()
   {
       Debug.Log("F隐藏");
        FNote.SetActive(false);
   }

   public void StartToTalk()
   {
    npcDialogueTreeController.StartDialogue();
   }

}
