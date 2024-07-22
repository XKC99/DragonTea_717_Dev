using System.Collections;
using System.Collections.Generic;
using DialogueSpeakerSpace;
using NodeCanvas.DialogueTrees;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public GameObject FNote;
   protected virtual void StartTalk()
   {
     Debug.Log("F显示取消"); 
     FNote.SetActive(false); //这里添加取消显示的逻辑
     this.GetComponent<DialogueTreeController>().StartDialogue();
   }

   protected virtual void OnCollisionEnter2D()
   {
     Debug.Log("F显示");
     FNote.SetActive(true);
   }

   protected virtual void OnCollisionExit2D()
   {
     Debug.Log("F隐藏");
     FNote.SetActive(false);
   }

}
