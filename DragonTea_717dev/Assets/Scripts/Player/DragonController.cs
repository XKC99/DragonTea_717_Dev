using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : PlayerController
{
    protected override void Update()
    {
        if (Input.GetKey("space") && !cantMove)  //按下空格，且在地面，且不能移动时才可添加力
        {
            
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }

        if(Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Fly");
            Debug.Log("起飞");
        }
        
       if(Input.GetKeyDown("f") && playerCollision.npcDialogueTreeController!= null)
        {
            playerCollision.FNoteDisable();
            playerCollision.StartToTalk();
        }

        if(Input.GetMouseButtonDown(0))
        {
            PlayerIsAttack();
            Debug.Log("我正在攻击");
            
        }
    }

    protected override void OnGroundChange(bool isOnGround)
    {
        //
    }

    
}
