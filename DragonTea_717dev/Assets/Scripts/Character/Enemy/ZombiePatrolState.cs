using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : BaseState
{
    public override void Enter(BaseEnemy enemy)
    {
        currentEnemy=enemy;
        currentEnemy.currentSpeed=currentEnemy.normalSpeed;
    }

    public override void LogicUpdate()
    {   
        //发现玩家切换到chase
        if(currentEnemy.FindPlayer())
        {
            currentEnemy.SwitchState(EnemyState.Chase);
        }

        //判断是否撞墙，若是，退出移动状态
        if((currentEnemy.physicsCheck.touchLeftWall&&currentEnemy.faceDirct.x<0)||(currentEnemy.physicsCheck.touchRightWall&&currentEnemy.faceDirct.x>0))
        {
            currentEnemy.wait=true;
            currentEnemy.anim.SetBool("Walk",false);
        }
        else
        {
            currentEnemy.anim.SetBool("Walk",true);
        }
        //!currentEnemy.physicsCheck.isGround||
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void Exit()
    {
        currentEnemy.anim.SetBool("Walk",false);
        Debug.Log("退出patrol状态");
    }
}
