using NodeCanvas.DialogueTrees;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = false;
    private bool facingRight = true;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
       MovePlayer();  
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
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
            case "Speak":
                var speak=collision.gameObject.GetComponent<DialogueSpeaker>();
                if(speak!=null)
                {
                    speak.Play();
                }
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        */
        switch(collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = false;
                break;
        }
    }

   //触发器检测↓
   private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.gameObject.CompareTag("NPC")) //为什么这里按下F没办法操作
    {
        var npc=other.gameObject.GetComponentInChildren<DialogueTreeController>();
            if(npc!=null)
            {
                npc.StartDialogue();
            }
        
    }
    
    /*
       switch(other.gameObject.tag)
       {
           case "NPC":
            var npc=other.gameObject.GetComponentInChildren<DialogueTreeController>();
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(npc!=null)
                {
                    npc.StartDialogue();
                }

            }
            break;
                
       }*/
   }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
}