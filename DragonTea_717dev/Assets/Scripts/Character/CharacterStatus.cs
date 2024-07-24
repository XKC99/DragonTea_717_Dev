using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP=1 ;
    public int currentHp=1;

    private Animator anim;

   
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHp <= 0)
        {
            CharacterIsDead();
        }
        if(currentHp ==maxHP)
        {
            CharacterIsHealthy();
        }

    }

    public virtual void CharacterIsDead()  
    {
        //TODO:这里添加死亡后的处理方法
       // anim.SetTrigger("Dead");为什么加了dead动画层后人物就朝上飘了
    }

    public virtual void CharacterIsHealthy()
    {
        //TODO:这里添加恢复成人的处理方法
        //Debug.Log("CharacterIsHealthy");
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }
    public void Heal(int heal)
    {
        currentHp += heal;
    }
}
