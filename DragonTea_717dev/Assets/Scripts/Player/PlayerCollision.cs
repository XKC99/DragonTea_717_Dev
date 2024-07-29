using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class PlayerCollision : ItemLogic,ICardAffected 
{

    private GameObject FNote;//靠近NPC显示的提示UI
    public DialogueTreeController npcDialogueTreeController;  //NPC身上的DialogueTreeController组件

    public override bool Execute(Card card)
    {
        switch(card.cardType)
        {
            // case CardType.Fire:
            //     Debug.Log("攻击");
            //     //player.GetComponent<PlayerController>().PlayerIsAttack();
            //     return true;
            // case CardType.Heal:
            //     Debug.Log("治疗");
            //     //player.GetComponent<PlayerController>().PlayerIsHeal();
            //     return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
            case CardType.Fly:
                Debug.Log("飞行");
                if(rb!=null)
                {
                    //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //给一个向上的力
                    rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
                }
                else{
                    Debug.Log("进行特殊处理"); 
                }
                return true;
            case CardType.Fall:
                Debug.Log("坠落");
                return true;
        }
        return false;
    }

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

    //卡牌功能相关如下
        //  if(other.gameObject.CompareTag("Card"))  //当卡牌拖拽到人物身上并释放时
        //  {
        //      other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
        //  }
        // if(other.gameObject.tag == "Fire")  //当人物接触到攻击火球时
        // {
        //     OnFire();
        //     Destroy(other.gameObject);
        // }
        // if(other.gameObject.tag == "Heal")  //当人物接触到治愈火球时
        // {
        //     Debug.Log("我被治愈了");
        // }
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
