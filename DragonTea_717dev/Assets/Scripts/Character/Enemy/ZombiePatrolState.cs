using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : BaseState
{
    public override void Enter(BaseEnemy enemy)
    {
        currentEnemy=enemy;
    }

    public override void LogicUpdate()
    {   
        //判断是否浮空或撞墙，若是，退出移动状态
        if((currentEnemy.physicsCheck.touchLeftWall&&currentEnemy.faceDirct.x<0)||(currentEnemy.physicsCheck.touchRightWall&&currentEnemy.faceDirct.x>0))
        {
            currentEnemy.wait=true;
            currentEnemy.anim.SetBool("Walk",false);
        }
        //!currentEnemy.physicsCheck.isGround||
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void Exit()
    {
        
    }
}
