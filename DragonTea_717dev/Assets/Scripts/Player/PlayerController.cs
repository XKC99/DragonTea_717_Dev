using NodeCanvas.DialogueTrees;
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
    public Vector2 mousePos;
    public Vector2 direction;


    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;
    private bool facingRight = true;
    private bool isDead= false;
    private bool isAttack = false;

    private PhysicsCheck physicsCheck;
    
    
    private PlayerCollision playerCollision;
    private bool cantMove => playerCollision.npcDialogueTreeController != null && playerCollision.npcDialogueTreeController.isRunning;


    private void Start()
    {
        playerCollision=GetComponent<PlayerCollision>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        physicsCheck=GetComponent<PhysicsCheck>();
        physicsCheck.onGroundChange += OnGroundChange;
    }

    private void FixedUpdate()
    {
        if (cantMove||isDead) {  //不能移动就动不了
            return;
        }

        MovePlayer();  
    }

    private void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     PlayerIsAttack();
        // }

        if (Input.GetKeyDown("space") && physicsCheck.isGround && !cantMove)  //按下空格，且在地面，且不能移动时才可添加力
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        
       if(Input.GetKeyDown("f") && playerCollision.npcDialogueTreeController!= null)
        {
            playerCollision.FNoteDisable();
            playerCollision.StartToTalk();
        }

    }

    private void MovePlayer()
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

     private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }



    //碰撞检测↓
    private void OnCollisionEnter2D(Collision2D collision)  
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
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
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
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

    private void OnGroundChange(bool isGround) 
    {
        if (isGround) {
            if (physicsCheck.LastVelocity.y < jumpDeadSpeed) {
                PlayerIsDead();
            }
        }
    }

    public void PlayerIsDead()  //这里是玩家死后执行的东西。可以添加很多具体内容。
    {
        isDead = true;
        animator.SetBool("Dead",true);
        
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

    public void ShootAttack()  //攻击牌生效后发射攻击火球
    {
        direction=(mousePos-new Vector2(transform.position.x,transform.position.y)).normalized;
        //transform.right=direction;
        GameObject fire=Instantiate(attackFireBall,fromPos.position,Quaternion.identity);
        fire.GetComponent<FireBall>().SetFireSpeed(direction);
    }

    public void ShootHeal()  //治疗牌生效后发射治疗火球
    {
        direction=(mousePos-new Vector2(transform.position.x,transform.position.y)).normalized;
        //transform.right=direction;
        GameObject fire=Instantiate(healFireBall,fromPos.position,Quaternion.identity);
        fire.GetComponent<FireBall>().SetFireSpeed(direction);
    }
   



}