using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : BaseEnemy
{
    protected override void Awake()
    {
        base.Awake();
        patrolState = new ZombiePatrolState();//里氏替换原则
    }

}
