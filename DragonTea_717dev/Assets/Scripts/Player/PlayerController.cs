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
    
    private bool cantMove => triggerNpc != null && triggerNpc.isRunning;  //判断是否能移动
    private DialogueTreeController triggerNpc;//存储triggerNPC记录
    private Item triggerItem;//存储triggerItem记录
    private GameObject triggertimelineObject;//存储triggertimeline的物体记录
    private GameObject triggerspeakObject;//存储triggerspeak的物体记录


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (Input.GetKeyDown("space") && isGrounded && !cantMove)  //按下空格，且在地面，且不能移动时才可添加力
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown("f") && triggerNpc!= null) {   //开启对话
            triggerNpc.StartDialogue();
        }

        if(Input.GetKeyDown("f") && triggerItem!=null) {   //收集物品
            triggerItem.ItemGet();
        }

        //播放完一次timeline后，将挂载timeline的空物体置为false↓
        if(triggertimelineObject!=null&&triggertimelineObject.GetComponent<PlayableDirector>().state != PlayState.Playing) 
        {
            triggertimelineObject.SetActive(false);
        }
        //播放完一次speak后，将挂载speak的空物体置为false↓
        if(triggerspeakObject!=null&&triggerspeakObject.GetComponent<DialogueSpeaker>().isFinished==true)
        {
            triggerspeakObject.SetActive(false); 
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
            case "Speak":
                var speak=collision.gameObject.GetComponent<DialogueSpeaker>();
                if(speak!=null)
                {
                    speak.Play();
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

   //触发器检测↓
   private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.gameObject.CompareTag("NPC")) //为什么这里按下F没办法操作：因为进入碰撞和按F几乎不可能同时发生
    {
        triggerNpc=other.gameObject.GetComponentInChildren<DialogueTreeController>();
        
    }
     if(other.gameObject.CompareTag("Item"))
    {
        triggerItem=other.gameObject.GetComponent<Item>();
    }
    if(other.gameObject.CompareTag("Timeline"))
    {
        triggertimelineObject = other.gameObject;
        triggertimelineObject.GetComponent<PlayableDirector>().Play();
    }
    if(other.gameObject.CompareTag("Speak"))
    {
        triggerspeakObject = other.gameObject;
        triggerspeakObject.GetComponent<DialogueSpeaker>().Play();
    }
   
   }

   private void OnTriggerExit2D(Collider2D other) 
   {
        if(other.gameObject.CompareTag("NPC"))
        {
            var npc=other.gameObject.GetComponentInChildren<DialogueTreeController>();
            if(triggerNpc == npc)
            {
                triggerNpc = null;
            }
        }
        if(other.gameObject.CompareTag("Item"))
        {
            var item=other.gameObject.GetComponent<Item>();
            if(triggerItem == item)
            {
                triggerItem = null;
            }
        }
   }


    

    
}