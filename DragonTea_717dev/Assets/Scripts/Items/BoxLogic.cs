using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BoxLogic : ItemLogic,ICardAffected 
{
    public string destroyBoxAudioName;
    public List<GameObject> cardColletions;
    // private GameObject player;
    // private void Awake()
    // {
    //     player=GameObject.FindGameObjectWithTag("Player");
    // }

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
     
    public override void AttackedByFireBall(Collider2D collider2D)
    {
        AudioManager.instance.PlayOneShot(destroyBoxAudioName);
          //Destroy(collider2D.gameObject);  //这里需要替换为存入对象池的方法
          SkillBallPool.Instance.PushBallObject(collider2D.gameObject);
          this.transform.DetachChildren();//隐藏的道具爆出来
          for(int i=0;i<cardColletions.Count;i++)
          {
              cardColletions[i].SetActive(true);
          }
          this.gameObject.SetActive(false);
    }



}
