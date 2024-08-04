using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemLogic : MonoBehaviour,ICardAffected //接口命名往往以I开头
{

   protected GameObject player;
   protected Rigidbody2D rb;
   public float jumpForce;
   public float gravityChangeScale;

   public UnityEvent gameObjectDestroyUnityEvent;

   protected virtual void Awake()
   {
      player=GameObject.FindGameObjectWithTag("Player");
      rb = GetComponent<Rigidbody2D>();
      if(rb==null)
      {
        return;
      }
   }

    public virtual bool Execute(Card card) 
    {
        switch(card.cardType)
        {
            case CardType.Fire:
                FireCardEffect();
                return true;
             case CardType.Heal:
                HealCardEffect();
                return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
             case CardType.Fly:
                FlyCardEffect();
                return true;
            case CardType.Fall:
                FallCardEffect();
                return true;
        }
        return false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
                break;
            case "Fire":
                AttackedByFireBall(other);
                break;
            case "Heal":
                HealedByHealBall(other);
                break;
        }
        
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteFalse(this);
                break;
        }

    }
    protected virtual void OnCollisionEnter2D()
    {
        rb.gravityScale=1.0f;
    }

    public virtual void FireCardEffect()
    {
        Debug.Log("攻击牌的作用");
        player.GetComponent<PlayerController>().PlayerIsAttack();
    }

    public virtual void HealCardEffect()
    {
        Debug.Log("治疗牌的作用");
        player.GetComponent<PlayerController>().PlayerIsHeal();
    }

    public virtual void FlyCardEffect()
    {
        Debug.Log("飞行牌的作用");
        if(rb!=null)
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        else{
            Debug.Log("进行特殊处理");
        }
    }

    public virtual void FallCardEffect()
    {
        rb.gravityScale=gravityChangeScale;
        Debug.Log("坠落牌的作用");
    }

    public virtual void AttackedByFireBall(Collider2D collider2D)
    {
        Debug.Log("我被火球攻击了");
        //Destroy(collider2D.gameObject);  //这里需要替换为存入对象池的方法
        SkillBallPool.Instance.PushBallObject(collider2D.gameObject);
        this.gameObject.SetActive(false);//将本物体设置为不可见
    }

    public virtual void HealedByHealBall(Collider2D collider2D)
    {
        Debug.Log("我被治愈了");
        Destroy(collider2D.gameObject);  //这里需要替换为存入对象池的方法
    }

    // public virtual void UpByFlyCard()
    // {
    //     Debug.Log("给一个向上的力");
    // }

    // public virtual void DownByFallCard()
    // {
    //     Debug.Log("缓慢坠落");
    // }

    public virtual void CannotUesCardOnThis()
    {
        this.GetComponentInChildren<DialogueSpeaker>().Play();
        Debug.Log("不能使用该牌");
    }

    protected virtual void OnGameObjectDestroy()
    {
        Debug.Log($"Trigger触发:{gameObject.name}");
        gameObjectDestroyUnityEvent?.Invoke();
    }




  
}
