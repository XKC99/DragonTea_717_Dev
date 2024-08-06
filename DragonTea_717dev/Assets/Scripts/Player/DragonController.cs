using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : PlayerController
{
    public float flySpeed;
    public float fireBallSpeed;
    public Vector2 fireBallDirection;
    public float fireRate; //火球发射间隔时间
    public float nextFireTime; //下次可以发射的时间
    public float fireLifeTime;//火焰存活时间

    //public GameObject playerAttackedByLavaSpeaker;

    public GameObject tipCanvas;
    public TextMeshProUGUI CD_Text;
    private string cdTip;
    private float recordMoveSpeed;
    

    protected override void Awake() 
    {
        base.Awake();
        recordMoveSpeed=moveSpeed;
        cdTip = CD_Text.text;
    }

    protected override void Update()
    {
        //Debug.Log("Dragon Velocity: " + rb.velocity);
        if (Input.GetKey("space") && !cantMove&&!isDead)  //按下空格，且在地面，且不能移动时才可添加力
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }

        if(Input.GetKeyDown("space")&&!isDead)
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

        if(Input.GetMouseButtonDown(0)&&!isDead)
        {
            if(Time.time>=nextFireTime)
            {
            PlayerIsAttack();
            Debug.Log("我正在攻击");
            nextFireTime=Time.time+fireRate;
            }
            else
            {
                Debug.Log("冷却中");
                //comp.text.Replace("ss", 30);
            }
            
        }
        
        var cd = nextFireTime-Time.time;
        if (cd > 0)
        {
            CD_Text.text = string.Format(cdTip, cd.ToString("F0"));
            tipCanvas.SetActive(true);
        }
        else
        {
            tipCanvas.SetActive(false);
        }
    }

    protected override void OnGroundChange(bool isOnGround)
    {
        if(isOnGround)
        {
            moveSpeed=recordMoveSpeed;
            // rb.gravityScale=2.0f;
        }

    }

    public void DragonDropIntoFireDieAndRevive()  //龙掉岩浆死亡
    {
        if(isDead)
        {
            return;
        }
        StartCoroutine("DragonDropIntoFireDieAndReviveCo");
    }    
    public IEnumerator DragonDropIntoFireDieAndReviveCo()
    {
        PlayerIsDead();
        playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
        yield return new WaitUntil(()=>playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }

    public void DragonAttackedByLava()  //龙被岩浆球攻击死亡
    {
        if(isDead)
        {
            return;
        }
        StartCoroutine("DragonAttackedByLavaCo");
    }

    // public IEnumerator DragonAttackedByLavaCo()
    // {
    //     PlayerIsDead();
    //     playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
    //     yield return new WaitUntil(()=>playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().isFinished);
    //     Revive();
    // }

    // public override void PlayerIsAttack()  //发射火球
    // {
    //     isAttack = true;
    //     Debug.Log("攻击");
    //     animator.SetTrigger("Attack");
    //     GameObject fireBall=SkillBallPool.Instance.GetBallObject(attackFireBall);
    //     fireBall.transform.position=fromPos.position;
    //     fireBall.GetComponent<Rigidbody2D>().velocity=fireBallDirection*fireBallSpeed;

    //     Destroy(fireBall,fireLifeTime);
    // }

    protected override void Flip()
    {
        base.Flip();
        fireBallDirection.x*=-1; //改变火球位置
    }

    
   
  



}
