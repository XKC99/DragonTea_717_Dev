using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLogic : ItemLogic,ICardAffected 
{
    public List<GameObject> DeadObject;
    public List<GameObject> BackToNPCObject;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {

        switch(other.gameObject.tag)
        {
            case "Player":
                Debug.Log("我被攻击了");
                this.gameObject.GetComponent<ZombieStatus>().TakeDamage(1); //每次被攻击一次掉1血
                break;
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
                //Debug.Log("发现卡牌");--实际功能
                break;
            case "Fire":
                AttackedByFireBall(other);
                break;
            case "Heal":
                HealedByHealBall(other);
                break;
        }


    }

    
    public void AfterDieShowCard()
    {
        DataManager.Instance.evilCount++;
        this.transform.DetachChildren();//隐藏的道具爆出来
        for(int i=0;i<DeadObject.Count;i++)
        {
            DeadObject[i].SetActive(true);
        }
        this.gameObject.SetActive(false); //怪物死亡

    }

    public void BackToNPCShowCard()
    {
        DataManager.Instance.evilCount--;
        this.transform.DetachChildren();
        for(int i=0;i<BackToNPCObject.Count;i++)
        {
            BackToNPCObject[i].SetActive(true);
        }
        this.gameObject.SetActive(false);//怪物消失
    }

    public override void AttackedByFireBall(Collider2D collider2D)
    {
         Destroy(collider2D.gameObject);  //这里需要替换为：将火球置入对象池
          //AudioManager.instance.PlayOneShot(destroyBoxAudioName);
          this.gameObject.GetComponent<ZombieStatus>().TakeDamage(1); //每次被攻击一次掉1血
    }

    public override void HealedByHealBall(Collider2D collider2D)
    {
         Debug.Log("我被治愈了");
        Destroy(collider2D.gameObject);  //这里需要替换为：将治愈球置入对象池
        this.gameObject.GetComponent<ZombieStatus>().Heal(1);
    }
}
