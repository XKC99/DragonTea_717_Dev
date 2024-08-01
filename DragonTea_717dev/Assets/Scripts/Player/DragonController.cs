using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : PlayerController
{
    public float flySpeed;
    public DialogueSpeaker playerAttackedByLavaSpeaker;
    private float recordMoveSpeed;

    private void Awake() {
        recordMoveSpeed=moveSpeed;
    }
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
            moveSpeed=flySpeed;
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
        if(isOnGround)
        {
            moveSpeed=recordMoveSpeed;
        }

    }

    public void DragonDropIntoFireDieAndRevive()  //龙掉岩浆死亡
    {
        StartCoroutine("DragonDropIntoFireDieAndReviveCo");
    }    
    public IEnumerator DragonDropIntoFireDieAndReviveCo()
    {
        PlayerIsDead();
        playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
        yield return new WaitUntil(()=>playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }

    public void DragonAttackedByLava()
    {
        StartCoroutine("DragonAttackedByLavaCo");
    }

    public IEnumerator DragonAttackedByLavaCo()
    {
        PlayerIsDead();
        playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
        yield return new WaitUntil(()=>playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }
    
}
