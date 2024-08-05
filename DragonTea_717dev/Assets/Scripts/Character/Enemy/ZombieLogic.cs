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

    public void ZombieDieEvent()
    {
        StartCoroutine(ZombieDieCo());
    }

    public IEnumerator ZombieDieCo()  //死亡的协程
    {
        this.gameObject.GetComponent<ZombieEnemy>().EnemyDie();
        rb.velocity=new Vector2(0,0);
        Debug.Log("协程yield");
        yield return new WaitForSeconds(2f);
        Debug.Log("协程after yield");
        GameObject gb1=this.transform.Find("p_sotai").gameObject;
        GameObject gb2=this.transform.Find("all_scale").gameObject;
        gb1.SetActive(false);
        gb2.SetActive(false);   
        AfterDieShowCard();
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
         //Destroy(collider2D.gameObject);  //这里需要替换为：将火球置入对象池
         SkillBallPool.Instance.PushBallObject(collider2D.gameObject);
          //AudioManager.instance.PlayOneShot(destroyBoxAudioName);
          this.gameObject.GetComponent<ZombieStatus>().TakeDamage(1); //每次被攻击一次掉1血
    }

    public override void HealedByHealBall(Collider2D collider2D)
    {
         Debug.Log("我被治愈了");
        //Destroy(collider2D.gameObject);  //这里需要替换为：将治愈球置入对象池
        SkillBallPool.Instance.PushBallObject(collider2D.gameObject);
        this.gameObject.GetComponent<ZombieStatus>().Heal(1);
    }
}
