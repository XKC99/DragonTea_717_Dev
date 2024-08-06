using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava :  ItemLogic
{
     public override bool Execute(Card card) 
    {
        switch(card.cardType)
        {
            // case CardType.Fire:
            //     FireCardEffect();
            //     return true;
             case CardType.Heal:
                HealCardEffect();
                return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
            //  case CardType.Fly:
            //     FlyCardEffect();
            //     return true;
            // case CardType.Fall:
            //     FallCardEffect();
            //     return true;
        }
        return false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayOneShot("sfireboom");
            Debug.Log("撞上了");
            //collision.GetComponent<DragonController>().DragonAttackedByLava();
            collision.GetComponent<PlayerController>().PlayerAttackedByLava();
            Destroy(gameObject); // 击中玩家后销毁子弹
        }

        if(collision.CompareTag("Heal"))
        {
            // AudioManager.Instance.PlayOneShot("shealboom");
            // Debug.Log($"撞上了(自身:{gameObject.name}_{gameObject.GetInstanceID()};对方:{collision.gameObject.name}_{collision.gameObject.GetInstanceID()})");
            // SkillBallPool.Instance.PushBallObject(collision.gameObject);
            // Destroy(gameObject); // 击中火球后销毁
            HealBallEffect(collision);
        }
        if(collision.CompareTag("Card"))
        {
            collision.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
        }
        
    }

    public void HealBallEffect(Collider2D collision)
    {
        AudioManager.Instance.PlayOneShot("shealboom");
            Debug.Log($"撞上了(自身:{gameObject.name}_{gameObject.GetInstanceID()};对方:{collision.gameObject.name}_{collision.gameObject.GetInstanceID()})");
            SkillBallPool.Instance.PushBallObject(collision.gameObject);
            Destroy(gameObject); // 击中火球后销毁
    }
}
