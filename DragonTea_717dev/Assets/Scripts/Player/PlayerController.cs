using NodeCanvas.DialogueTrees;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;
    private bool facingRight = true;

    private PhysicsCheck physicsCheck;
    
    
    private PlayerCollision playerCollision;
    private bool cantMove => playerCollision.npcDialogueTreeController != null && playerCollision.npcDialogueTreeController.isRunning;


    private void Start()
    {
        playerCollision=GetComponent<PlayerCollision>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        physicsCheck=GetComponent<PhysicsCheck>();
    }

    private void FixedUpdate()
    {
        
        if (cantMove) {  //不能移动就动不了
            return;
        }

        MovePlayer();  
    }

    private void Update()
    {
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
   



}