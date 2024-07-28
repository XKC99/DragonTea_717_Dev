using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxLogic : ItemLogic,ICardAffected 
{
    public string AudioName;
    // private GameObject player;
    // private void Awake()
    // {
    //     player=GameObject.FindGameObjectWithTag("Player");
    // }

    // public bool Execute(Card card) 
    // {
    //     switch(card.cardType)
    //     {
    //         case CardType.Fire:
    //             Debug.Log("攻击");
    //             player.GetComponent<PlayerController>().PlayerIsAttack();
    //             return true;
    //          case CardType.Heal:
    //              Debug.Log("治疗");
    //              return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
    //         case CardType.Fly:
    //             Debug.Log("飞行");
    //             return true;
    //         case CardType.Fall:
    //             Debug.Log("坠落");
    //             return true;
    //     }

       

    //     return false;
    // }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollider(AudioName);
           // OnBoxCollision();
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Fire")
      {
          OnFire();
      }
      if(other.gameObject.tag == "Card")
      {
        other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
        //Debug.Log("发现卡牌");--实际功能
      }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Card")
        {
            other.gameObject.GetComponent<CardHandler>().SetExcuteFalse(this);
            //Debug.Log("离开卡牌");--实际功能
        }

    }
    override protected void OnCollider(string AudioName)
    {
        //AudioName=this.AudioName;
        AudioManager.instance.PlayOneShot(AudioName);
    }


   
}
