using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour,IFireHitandHeal  //接口命名往往以I开头
{

   protected GameObject player;
   protected Rigidbody2D rb;
   public float jumpForce=10f;
   protected virtual void Awake()
   {
      player=GameObject.FindGameObjectWithTag("Player");
      rb=this.gameObject.GetComponent<Rigidbody2D>();
      if(rb==null)
      {
        Debug.Log("当前对象不村子Rigidbody2D");
        return;
      }

   }

    public virtual bool Execute(Card card) 
    {
        switch(card.cardType)
        {
            case CardType.Fire:
                Debug.Log("攻击");
                player.GetComponent<PlayerController>().PlayerIsAttack();
                return true;
            case CardType.Heal:
                Debug.Log("治疗");
                player.GetComponent<PlayerController>().PlayerIsHeal();
                return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
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
    
    protected virtual void OnCollider(string AudioName)
    {
        
    }

  
   public virtual void OnFire()  //这里是接口提供的方法，需要实现
   {
    Debug.Log("我被攻击了");

   }

    public void OnHeal()//这里是接口提供的方法，需要实现
    {
       Debug.Log("我被治疗了");
    }


}
