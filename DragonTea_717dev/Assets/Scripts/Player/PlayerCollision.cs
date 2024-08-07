using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class PlayerCollision : ItemLogic,ICardAffected 
{

    private GameObject FNote;//靠近NPC显示的提示UI
    public Texture2D playerImage;
    public Texture2D playerOldImage;
    public DialogueTreeController npcDialogueTreeController;  //NPC身上的DialogueTreeController组件

    public float recordGravityScale;

    private void Start() 
    {
        recordGravityScale=this.GetComponent<Rigidbody2D>().gravityScale;
    }


    public override bool Execute(Card card)
    {
        switch(card.cardType)
        {
            case CardType.Fire:
                FireCardEffect();
                return true;
            //  case CardType.Heal:
            //     HealCardEffect();
            //     return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
             case CardType.Fly:
                FlyCardEffect();
                return true;
            case CardType.Fall:
                FallCardEffect();
                return true;
        }
        return false;

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "NPC":
                FNote=other.transform.Find("Canvas").gameObject;
                npcDialogueTreeController=other.GetComponentInChildren<DialogueTreeController>();
                Debug.Log("F显示");
                FNote.SetActive(true);
                break;
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
                //Debug.Log("发现卡牌");--实际功能
                break;
        }

        
   }


   protected override void OnTriggerExit2D(Collider2D other)
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
        else if(other.gameObject.CompareTag("Card"))  //当卡牌拖拽到人物身上并释放时
        {
            other.gameObject.GetComponent<CardHandler>().SetExcuteFalse(this);
        }

   }


    protected override void OnCollisionEnter2D()
    {
        rb.gravityScale=recordGravityScale;
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

    public void ChangeToOldImage()  //变成曾经的勇者形象
    {
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].mainTexture = playerOldImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].mainTexture = playerOldImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].mainTexture = playerOldImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[3].mainTexture = playerOldImage;
    }

    public void ChangeToNowImage() //变成现在的勇者形象
    {
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].mainTexture = playerImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].mainTexture = playerImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].mainTexture = playerImage;
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[3].mainTexture = playerImage;
    }
    public override void FireCardEffect()
    {
       Debug.Log("攻击");
       this.gameObject.GetComponent<PlayerStatus>().TakeDamage(1); //每次被攻击一次掉1血
    }

    public override void FallCardEffect()
    {
        if(rb.velocity.y>=0)
        {
            Debug.Log("没有用");
            //加上语音
        }
        else
        {
            rb.gravityScale=gravityChangeScale;
            //加上音效
            Debug.Log("坠落牌的作用");
        }
    }



}
