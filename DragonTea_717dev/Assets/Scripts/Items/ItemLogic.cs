using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour,IFireHitandHeal  //接口命名往往以I开头
{

   protected GameObject player;
   protected virtual void Awake()
   {
      player=GameObject.FindGameObjectWithTag("Player");
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
                 return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
            case CardType.Fly:
                Debug.Log("飞行");
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

   protected virtual void OnFirehaha()
   {
      Debug.Log("OnFire-我被火球打到了！");
   }

   public virtual void OnFire()  //这里是接口提供的方法，需要实现
   {
    Debug.Log("我被击中了");

   }

    public void OnHeal()//这里是接口提供的方法，需要实现
    {
       Debug.Log("我被治疗了");
    }
}
