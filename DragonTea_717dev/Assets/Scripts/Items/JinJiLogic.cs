using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinJiLogic : ItemLogic,ICardAffected 
{
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
            //  case CardType.Fly:
            //     FlyCardEffect();
            //     return true;
            // case CardType.Fall:
            //     FallCardEffect();
            //     return true;
        }
        return false;
    }

    public override void AttackedByFireBall(Collider2D collider2D)
    {
        Debug.Log("我被大火球攻击了");
        //Destroy(collider2D.gameObject);  //这里需要替换为存入对象池的方法
        OnGameObjectDestroy();
        SkillBallPool.Instance.PushBallObject(collider2D.gameObject);
        this.gameObject.SetActive(false);//将本物体设置为不可见
    }


    
}
