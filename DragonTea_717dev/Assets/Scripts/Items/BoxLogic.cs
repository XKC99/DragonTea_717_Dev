using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoxLogic : ItemLogic,ICardAffected 
{
    public string destroyBoxAudioName;
    private Rigidbody2D rb;
    public List<GameObject> cardColletions;
    // private GameObject player;
    // private void Awake()
    // {
    //     player=GameObject.FindGameObjectWithTag("Player");
    // }
    override protected void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    public override bool Execute(Card card) 
    {
      switch(card.cardType)
        {
            case CardType.Fire:
                Debug.Log("攻击");
                player.GetComponent<PlayerController>().PlayerIsAttack();
                return true;
            // case CardType.Heal:
            //     Debug.Log("治疗");
            //     player.GetComponent<PlayerController>().PlayerIsHeal();
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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Fire")
      {
          OnFire();
          AudioManager.instance.PlayOneShot(destroyBoxAudioName);
          Destroy(other.gameObject);  //这里需要替换为存入对象池的方法
          this.transform.DetachChildren();//隐藏的道具爆出来
          for(int i=0;i<cardColletions.Count;i++)
          {
              cardColletions[i].SetActive(true);
          }
          this.gameObject.SetActive(false);
      }
      if(other.gameObject.tag == "Heal")
      {
        Debug.Log("我被治愈了");
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


    // override protected void OnCollider(string AudioName)
    // {
    //     //AudioName=this.AudioName;
    //     AudioManager.instance.PlayOneShot(AudioName);
    // }


   
}
