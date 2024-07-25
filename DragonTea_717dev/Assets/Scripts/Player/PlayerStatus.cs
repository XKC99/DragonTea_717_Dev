using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        if(currentHp <= 0)
        {
            OnCharacterIsDead();
        }
        if(currentHp ==maxHP)
        {
            OnCharacterIsHealthy();
        }
    }

    // Update is called once per frame
    void Update()
    {
         if(currentHp <= 0)
        {
            OnCharacterIsDead();
        }
        if(currentHp ==maxHP)
        {
            OnCharacterIsHealthy();
        }
    }
}
