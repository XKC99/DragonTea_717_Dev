using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP ;
    public int currentHp;

    void Start()
    {
       
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

    public virtual void CharacterIsDead()  //在这里添加死亡后的处理方法
    {
        this.gameObject.SetActive(false);
    }
    public virtual void CharacterIsHealthy()
    {
        //TODO:这里添加恢复成人的处理方法
        Debug.Log("CharacterIsHealthy");
    }
}
