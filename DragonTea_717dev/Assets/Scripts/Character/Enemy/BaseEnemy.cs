using System.Collections;
using System.Collections.Generic;
using ParadoxNotion;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders.Simulation;

public class BaseEnemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    //protected Animator anim;  父类已有
    [Header("基本参数")]
    // Start is called before the first frame update
    [HideInInspector]public PhysicsCheck physicsCheck;
    [HideInInspector]public Animator anim;
    public float normalSpeed;
    public float chaseSpeed;
    public float currentSpeed;
    [HideInInspector]public Vector3 faceDirct;  //面朝方向

    [Header("状态")]
    protected bool isDead;
    protected bool isAttack;
    protected BaseState patrolState;
    protected BaseState currentState;
    protected BaseState chaseState;

    [Header("检测")]
    public Vector2 centerOffset;
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attackLayer;


    [Header("计时器")]
    public float waitTime;
    public float waitTimeCounter;
    public bool wait;

    public float losePlayerTime;
    public float losePlayerTimeCounter;
 
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
        currentState=patrolState;
        currentState.Enter(this);
    }

    
   void Update()
    {
        
        faceDirct=new Vector3(-transform.localScale.x,0,0); //控制形象方向
        
        /*
        if((physicsCheck.touchLeftWall&&faceDirct.x<0)||(physicsCheck.touchRightWall&&faceDirct.x>0))
        {
            wait=true;
            anim.SetBool("Walk",false);
        }*/
        
        currentState.LogicUpdate();  //执行不同条件下状态的切换(逻辑相关)
        TimeCounter();

    }

   
    protected virtual void FixedUpdate()  //让不同敌人的移动方式不同
    {
        if(!isDead)
        {
             EneymyMove();
        }
        currentState.PhysicsUpdate();  //执行不同条件下状态的切换(物理相关)
        
    }

  
    private void OnDisable()
    {
        currentState.Exit();
    }

    public virtual void EneymyMove()
    {   
        //当玩家死亡，
        if(DataManager.Instance.isPlayerDead==true) 
        {
            anim.SetBool("Walk",false);
            return;
        }//停止移动
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

        if(!FindPlayer()&&losePlayerTimeCounter>0)
        {
            losePlayerTimeCounter-=Time.deltaTime;
        }
        else
        {
            losePlayerTimeCounter=losePlayerTime;
        }
    }


    public void Flip()
    {
        //transform.localScale=new Vector3(faceDirct.x,2,-1);  //后面2个值是因为本身素材大小的问题，一般是1，1
        transform.localScale=new Vector3(faceDirct.x,transform.localScale.y,transform.localScale.z);
    }

    public void HurtPlayer()
    {
        anim.SetTrigger("Hurt");
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

    public bool FindPlayer()
    {
       return Physics2D.BoxCast(transform.position+(Vector3)centerOffset,checkSize,0,faceDirct,checkDistance,attackLayer);
    }

    public void SwitchState(EnemyState enemyState)
    {
        var newState=enemyState switch
        {
            EnemyState.Patrol => patrolState,
            EnemyState.Chase => chaseState,
            _ => null
        };
        currentState.Exit();
        currentState=newState;
        currentState.Enter(this);
        
    }
 
    
    public void DestroyAfterDeadAnimPlayed()
    {
        Debug.Log("销毁僵尸");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position+(Vector3)centerOffset+new Vector3(checkDistance*-transform.localScale.x,0,0),0.2f);
    }

    
    


}
