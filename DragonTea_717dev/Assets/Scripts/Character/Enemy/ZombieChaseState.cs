using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChaseState : BaseState
{
    public override void Enter(BaseEnemy enemy)
    {
       currentEnemy=enemy;
       //Debug.Log("Entered Chase State");
       currentEnemy.currentSpeed=currentEnemy.chaseSpeed;
       //currentEnemy.anim.SetBool("Walk",true);//奔跑和行走动画是一个。如果不同就换词

    }

    public override void LogicUpdate()
    {
        if(currentEnemy.losePlayerTimeCounter<=0)
        {
            currentEnemy.SwitchState(EnemyState.Patrol);
        }
       //判断是否撞墙，若是，退出移动状态
        if((currentEnemy.physicsCheck.touchLeftWall&&currentEnemy.faceDirct.x<0)||(currentEnemy.physicsCheck.touchRightWall&&currentEnemy.faceDirct.x>0))
        {
           Flip();
        }
    }

    public override void PhysicsUpdate()
    {
        
    }

    
    public override void Exit()
    {
        currentEnemy.losePlayerTimeCounter=currentEnemy.losePlayerTime;
        Debug.Log("退出chase状态");
    }

    public void Flip()
    {
        currentEnemy.transform.localScale=new Vector3(currentEnemy.faceDirct.x,2,-1);  //后面2个值是因为本身素材大小的问题，一般是1，1
    }
}
