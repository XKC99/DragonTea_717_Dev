using System.Collections;
using NodeCanvas.DialogueTrees;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private float slowMoveSpeed=1f;
    public float jumpForce = 10f;
    public float jumpDeadSpeed=-10f;   //落地时死亡速度

    public bool isInSlowZone;

    public GameObject attackFireBall;
    public GameObject healFireBall;
    public Transform fromPos;
    public Transform RevivePos;
    [HideInInspector]public Vector2 mousePos;
    [HideInInspector]public Vector2 direction;

    public GameObject playerFallToDeadSpeaker;  //高空坠落死亡对话
    public GameObject playerDeadByEnemySpeaker; //被敌人攻击死亡对话
    public GameObject playerAttackedByLavaSpeaker;//被岩浆攻击死亡对话
    public DialogueSpeaker playKillHimSelfSpeaker;//勇者自杀音
    

    [HideInInspector]public Rigidbody2D rb;
    protected Animator animator;

    // protected float recordGravityScale;

    protected bool isGrounded = false;
    [SerializeField]protected bool facingRight = true;
    protected bool isDead= false;
    protected bool isAttack = false;

    protected bool isTimelineing=false;

    protected PhysicsCheck physicsCheck;
    
    protected PlayerCollision playerCollision;
    protected bool cantMove => playerCollision.npcDialogueTreeController != null && playerCollision.npcDialogueTreeController.isRunning;

    protected virtual void Awake()
    {
        playerCollision=GetComponent<PlayerCollision>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        physicsCheck=GetComponent<PhysicsCheck>();
        physicsCheck.onGroundChange += OnGroundChange;
        
    }
    
    // protected void Start()
    // {
    //     playerCollision=GetComponent<PlayerCollision>();
    //     rb = GetComponent<Rigidbody2D>();
    //     animator = GetComponent<Animator>();

    //     physicsCheck=GetComponent<PhysicsCheck>();
    //     physicsCheck.onGroundChange += OnGroundChange;
    // }

    protected void FixedUpdate()
    {
        if (cantMove||isDead||isTimelineing) {  //不能移动就动不了
            return;
        }

        MovePlayer();  
    }

    protected virtual void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     PlayerIsAttack();
        // }
        if (Input.GetKeyDown("space") && physicsCheck.isGround && !cantMove&&!isDead)  //按下空格，且在地面，且不能移动时才可添加力
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        
       if(Input.GetKeyDown("f") && playerCollision.npcDialogueTreeController!= null)
        {
            playerCollision.FNoteDisable();
            animator.SetFloat("Speed",0f);
            playerCollision.StartToTalk();
        }

    }

    protected void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
          // 检查玩家是否在减速区域内
        if (isInSlowZone)
        {
            if (moveX > 0)
            {
                // 当玩家按下右键时，减慢速度
                rb.velocity = new Vector2(moveX * slowMoveSpeed, rb.velocity.y);
            }
            else if (moveX < 0)
            {
                // 当玩家按下左键时，恢复正常速度
                rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
            }
            else
            {
                // 没有按键时保持当前速度
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            // 如果不在减速区域内，保持正常速度
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        }

        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
        animator.SetFloat("Speed",Mathf.Abs(moveX));
    }

    protected virtual void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }



    //碰撞检测↓
    protected void OnCollisionEnter2D(Collision2D collision)  
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                //rb.gravityScale=1f;
                break;
            case "Teleport":
                var teleport =collision.gameObject.GetComponent<Teleport>();
                if(teleport!=null)
                {
                    teleport.TeleportToScene();
                }
                break;
            case"Box":
                isGrounded = true;
                //rb.gravityScale=1f;
                break;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = false;
                break;
            case "Box":
                isGrounded = false;
                break;
        }
        
    }

    protected virtual void OnGroundChange(bool isGround) 
    {
        if (isGround) {
            if (physicsCheck.LastVelocity.y < jumpDeadSpeed) {
                //PlayerIsDead();
                //playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
                StartCoroutine(PlayerJumpToDieAndReviveCo());
            }
        }
    }

     public IEnumerator PlayerJumpToDieAndReviveCo()  //玩家坠崖死亡
    {
        PlayerIsDead();
        AudioManager.Instance.PlayOneShot("sgaochuzhuiluo"); //勇者倒地音效
        playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
        yield return new WaitUntil(()=>playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }

    public void PlayerDeadByEnemy()  //调用玩家被敌人攻击死亡的协程
    {
        StartCoroutine(PlayerDeadByEnemyCo());
    }
    public IEnumerator PlayerDeadByEnemyCo()  //玩家被敌人攻击死亡
    {
        PlayerIsDead();
        if(DataManager.Instance.isNotFirstDeadByEnemy==false)
        {
            DataManager.Instance.firstDeadByEnemySpeaker.Play(); //第一次被攻击死亡播放的语音
            yield return new WaitUntil(()=>DataManager.Instance.firstDeadByEnemySpeaker.isFinished);
            DataManager.Instance.isNotFirstDeadByEnemy=true;
        }
        else
        {
            playerDeadByEnemySpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家被敌人攻击死亡后播放语音
            yield return new WaitUntil(()=>playerDeadByEnemySpeaker.GetComponent<DialogueSpeaker>().isFinished);
        }
        //playerDeadByEnemySpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家被敌人攻击死亡后播放语音
        //yield return new WaitUntil(()=>playerDeadByEnemySpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }

    public virtual void PlayerIsDead()  //这里是玩家死后执行的东西。可以添加很多具体内容。
    {
        isDead = true;
        animator.SetBool("Dead",true);
        AudioManager.Instance.PlayOneShot("sdaodi"); //勇者倒地音效
        DataManager.Instance.isPlayerDead=true;
    }
    public void Revive()  //玩家复活
    {
        this.transform.localPosition=RevivePos.position;
        isDead = false;
        animator.SetBool("Dead",false);
        DataManager.Instance.isPlayerDead=false;
    }
   
    public virtual void PlayerIsAttack()  //使用攻击牌后玩家的操作
    {
        AudioManager.Instance.PlayOneShot("sshoot"); //勇者攻击音效
        isAttack = true;
        Debug.Log("攻击");
        animator.SetTrigger("Attack");
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ShootAttack();
    }

    public void PlayerIsHeal()  //使用治疗牌后玩家的操作
    {
        AudioManager.Instance.PlayOneShot("sshoot"); //勇者攻击音效
        Debug.Log("治疗");
        animator.SetTrigger("Attack");
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ShootHeal();
    }

    public void PleyIsSlowlyFall() //使用下落牌后玩家的操作
    {
        Debug.Log(" SlowlyFall");

    }

    public virtual void ShootAttack()  //攻击牌生效后发射攻击火球
    {
        direction=(mousePos-new Vector2(fromPos.position.x,fromPos.position.y)).normalized;
        //transform.right=direction;不需要
        //GameObject fire=Instantiate(attackFireBall,fromPos.position,Quaternion.identity); 换成下2行
        GameObject fireBall=SkillBallPool.Instance.GetBallObject(attackFireBall);

        if(facingRight) //这里是改变火球的方向
        {
            fireBall.GetComponent<SpriteRenderer>().flipX=true;
        }
        else
        {
            fireBall.GetComponent<SpriteRenderer>().flipX=false;
        }

        fireBall.transform.position=fromPos.position;
        Debug.Log("攻击球实例化");
        //fire.GetComponent<FireBall>().SetFireSpeed(direction);//换成下1行
        fireBall.GetComponent<FireBall>().SetFireSpeed(direction);
    }

    public void ShootHeal()  //治疗牌生效后发射治疗火球
    {
        direction=(mousePos-new Vector2(transform.position.x,transform.position.y)).normalized;
        //transform.right=direction;
        GameObject fire=Instantiate(healFireBall,fromPos.position,Quaternion.identity);
        if(facingRight)
        {
            healFireBall.GetComponent<SpriteRenderer>().flipX=true;
        }
        else
        {
            healFireBall.GetComponent<SpriteRenderer>().flipX=false;
        }
        Debug.Log("治疗球实例化");
        fire.GetComponent<FireBall>().SetFireSpeed(direction);
    }

    // public void Revive()
    // {
    //     StartCoroutine("");
    // }

   public void TimelineStartToStopMove()  //Timeline开始时，禁止移动
   {
    Debug.Log("TimelineStartToStopMove");
    this.rb.velocity=new Vector2(0f,0f);
    isTimelineing=true;
    this.rb.bodyType=RigidbodyType2D.Kinematic;//将刚体类型改为Kinematic，禁止运动
    animator.SetFloat("Speed",0f);
   }

    public virtual void TimelineEndToStartMove()  //Timeline结束时，允许移动
   {
    isTimelineing=false;
    this.rb.bodyType=RigidbodyType2D.Dynamic;//将刚体类型改为Dynamic，允许运动
   }

   public void TimelineStartMoon()  //月光Timelin部分特殊处理
   {
    isTimelineing=true;
    animator.SetFloat("Speed",0f);
    // this.GetComponent<Rigidbody2D>().gravityScale=0f;
   }

   public void ChangeReviePos(Vector3 newpos)
   {
        RevivePos.position=newpos;
   }

    public void PlayerDropIntoFireDieAndRevive()  //玩家掉岩浆死亡
    {
        if(isDead)
        {
            return;
        }
        StartCoroutine("PlayerDropIntoFireDieAndReviveCo");
    }    
    public IEnumerator PlayerDropIntoFireDieAndReviveCo()
    {
        PlayerIsDead();
        Debug.Log("Waiting for dialogue to finish...");
        playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家坠落死亡后播放语音
        yield return new WaitUntil(()=>playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Debug.Log("Dialogue finished, reviving player.");
        Revive();
    }

    
    public virtual void PlayerAttackedByLava()  //玩家被岩浆球攻击死亡
    {
        if(isDead)
        {
            return;
        }
        StartCoroutine("PlayerAttackedByLavaCo");
    }

    protected virtual IEnumerator PlayerAttackedByLavaCo()
    {
        AudioManager.Instance.PlayOneShot("sboom");
        PlayerIsDead();
        playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().Play();  //玩家被火球攻击死亡后播放语音
        yield return new WaitUntil(()=>playerAttackedByLavaSpeaker.GetComponent<DialogueSpeaker>().isFinished);
        Revive();
    }

    public virtual void PlayerKillHimeSelf()
    {
        if(isDead)
        {
            return;
        }
        StartCoroutine("PlayKillHimSelfCo");
    }

    protected virtual IEnumerator PlayKillHimSelfCo()
    {
        AudioManager.Instance.PlayOneShot("sboom");
        PlayerIsDead();
        playKillHimSelfSpeaker.Play();
        yield return new WaitUntil(()=>playKillHimSelfSpeaker.isFinished);
        gameObject.GetComponent<PlayerStatus>().currentHp++;
        Revive();
    }



}