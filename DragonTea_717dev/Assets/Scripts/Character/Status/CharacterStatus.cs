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
    public UnityEvent DeadEvent;
    public UnityEvent HealEvent;
   
    public virtual void OnCharacterIsDead()  
    {
        //TODO:这里添加死亡后的处理方法
       Debug.Log("CharacterIsDead");
       DeadEvent?.Invoke();
    }

    public virtual void OnCharacterIsHealthy()
    {
        //TODO:这里添加恢复成人的处理方法
       // Debug.Log("CharacterIsHealthy");
        HealEvent?.Invoke();
    }
    public virtual void TakeDamage(int damage)
    {
        AudioManager.Instance.PlayOneShot("sjizhong");
        currentHp -= damage;
    }
    public virtual void Heal(int heal)
    {
        AudioManager.Instance.PlayOneShot("sjizhong");
        currentHp += heal;
    }
}
