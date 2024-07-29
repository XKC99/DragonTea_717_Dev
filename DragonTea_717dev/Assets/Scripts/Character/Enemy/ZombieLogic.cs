using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLogic : ItemLogic,ICardAffected 
{
    public List<GameObject> DeadObject;
    public List<GameObject> BackToNPCObject;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Fire")
      {
          OnFire();
          Destroy(other.gameObject);  //这里需要替换为：将火球置入对象池
          //AudioManager.instance.PlayOneShot(destroyBoxAudioName);
          this.gameObject.GetComponent<ZombieStatus>().TakeDamage(1); //每次被攻击一次掉1血
      }
      if(other.gameObject.tag == "Heal")
      {
        Debug.Log("我被治愈了");
        Destroy(other.gameObject);  //这里需要替换为：将治愈球置入对象池
        this.gameObject.GetComponent<ZombieStatus>().Heal(1);
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
}
