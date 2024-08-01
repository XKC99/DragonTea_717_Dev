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
}
