using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.Events;

public class CharacterStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP;
    public int currentHp;

    [HideInInspector]public Animator anim;
    public UnityEvent DeadEvent;

   
   void Start()
    {
       //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(currentHp <= 0)
        {
            OnCharacterIsDead();
        }
        if(currentHp ==maxHP)
        {
            OnCharacterIsHealthy();
        }
        */

    }

    public virtual void OnCharacterIsDead()  
    {
        //TODO:这里添加死亡后的处理方法
       // anim.SetTrigger("Dead");为什么加了dead动画层后人物就朝上飘了
       Debug.Log("CharacterIsDead");
       DeadEvent?.Invoke();
    }

    public virtual void OnCharacterIsHealthy()
    {
        //TODO:这里添加恢复成人的处理方法
        Debug.Log("CharacterIsHealthy");
    }
    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
    }
    public virtual void Heal(int heal)
    {
        currentHp += heal;
    }
}
