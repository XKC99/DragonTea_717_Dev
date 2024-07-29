using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatus : CharacterStatus
{
    
    void Start()
    {
        
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
