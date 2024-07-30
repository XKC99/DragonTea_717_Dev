using NodeCanvas.DialogueTrees;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float jumpDeadSpeed=-10f;   //落地时死亡速度

    public GameObject attackFireBall;
    public GameObject healFireBall;
    public Transform fromPos;
    [HideInInspector]public Vector2 mousePos;
    [HideInInspector]public Vector2 direction;

    public GameObject playerFallToDeadSpeaker;


    protected Rigidbody2D rb;
    protected Animator animator;

    protected bool isGrounded = false;
    protected bool facingRight = true;
    protected bool isDead= false;
    protected bool isAttack = false;

    protected PhysicsCheck physicsCheck;
    
    protected PlayerCollision playerCollision;
    protected bool cantMove => playerCollision.npcDialogueTreeController != null && playerCollision.npcDialogueTreeController.isRunning;


    protected void Start()
    {
        playerCollision=GetComponent<PlayerCollision>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        physicsCheck=GetComponent<PhysicsCheck>();
        physicsCheck.onGroundChange += OnGroundChange;
    }

    protected void FixedUpdate()
    {
        if (cantMove||isDead) {  //不能移动就动不了
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
            playerCollision.StartToTalk();
        }

    }

    protected void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

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

    protected void Flip()
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
                rb.gravityScale=1f;
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
                rb.gravityScale=1f;
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
                PlayerIsDead();
                playerFallToDeadSpeaker.GetComponent<DialogueSpeaker>().Play(); 
            }
        }
    }

    public void PlayerIsDead()  //这里是玩家死后执行的东西。可以添加很多具体内容。
    {
        isDead = true;
        animator.SetBool("Dead",true);
        DataManager.Instance.isPlayerDead=true;
        
    }

    public void PlayerIsAttack()  //使用攻击牌后玩家的操作
    {
        isAttack = true;
        Debug.Log("攻击");
        animator.SetTrigger("Attack");
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ShootAttack();
    }

    public void PlayerIsHeal()  //使用治疗牌后玩家的操作
    {
        Debug.Log("治疗");
        animator.SetTrigger("Attack");
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ShootHeal();
    }

    public void PleyIsSlowlyFall() //使用下落牌后玩家的操作
    {
        Debug.Log(" SlowlyFall");

    }

    public void ShootAttack()  //攻击牌生效后发射攻击火球
    {
        direction=(mousePos-new Vector2(transform.position.x,transform.position.y)).normalized;
        //transform.right=direction;不需要
        //GameObject fire=Instantiate(attackFireBall,fromPos.position,Quaternion.identity); 换成下2行
        GameObject fireBall=SkillBallPool.Instance.GetBallObject(attackFireBall);
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
        Debug.Log("治疗球实例化");
        fire.GetComponent<FireBall>().SetFireSpeed(direction);
    }
   



}