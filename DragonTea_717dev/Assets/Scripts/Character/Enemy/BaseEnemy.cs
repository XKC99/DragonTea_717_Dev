using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders.Simulation;

public class BaseEnemy : CharacterStatus
{
    protected Rigidbody2D rb;
    //protected Animator anim;  父类已有
    [Header("基本参数")]
    // Start is called before the first frame update
    [HideInInspector]public PhysicsCheck physicsCheck;
    public float normalSpeed;
    public float chaseSpeed;
    public float currentSpeed;
    [HideInInspector]public Vector3 faceDirct;  //面朝方向

    protected bool isDead;
    protected bool isAttack;

    [Header("计时器")]
    public float waitTime;
    public float waitTimeCounter;
    public bool wait;
 
    protected virtual void Awake()
    {
        waitTimeCounter=waitTime;
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        physicsCheck=GetComponent<PhysicsCheck>();
        currentSpeed=normalSpeed;
    }
    void Start()
    {
        
    }


    private void OnEnable()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        if(currentHp <= 0)
        {
            OnCharacterIsDead();
        }
        if(currentHp ==maxHP)
        {
            OnCharacterIsHealthy();
        }

        faceDirct=new Vector3(-transform.localScale.x,0,0); //控制形象方向
        
        if((physicsCheck.touchLeftWall&&faceDirct.x<0)||(physicsCheck.touchRightWall&&faceDirct.x>0))
        {
            wait=true;
            anim.SetBool("Walk",false);
        }
        

      
        TimeCounter();
        


    }

   
    protected virtual void FixedUpdate()  //让不同敌人的移动方式不同
    {
        if(!isDead)
        {
             EneymyMove();
        }
        //currentState.PhysicsUpdate();  //执行不同条件下状态的切换(物理相关)
        
    }

  
    private void OnDisable()
    {
       // currentState.Exit();
    }

    public virtual void EneymyMove()
    {   
        rb.velocity=new Vector2(faceDirct.x*currentSpeed*Time.deltaTime,rb.velocity.y);
        anim.SetBool("Walk",true);
    }

    public void TimeCounter()
    {
        if(wait)
        {
            waitTimeCounter-=Time.deltaTime;
            if(waitTimeCounter<=0)
            {
                wait=false;
                waitTimeCounter=waitTime;
                Flip();
            }

        }
    }

    public void Flip()
    {
        transform.localScale=new Vector3(faceDirct.x,2,-1);  //后面2个值是因为本身素材大小的问题，一般是1，1
    }

    public void GetDamage()
    {
        //受伤被击退
    }

    public void EnemyDie()
    {
        anim.SetBool("Dead",true);
        isDead=true;
    }
 
    
    public void DestroyAfterDeadAnimPlayed()
    {
        Debug.Log("销毁僵尸");
        Destroy(gameObject);
    }


}
