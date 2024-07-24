using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders.Simulation;

public class BaseEnemy : CharacterStatus
{
    protected Rigidbody2D rb;
    protected Animator anim;
    [Header("基本参数")]
    // Start is called before the first frame update
    PhysicsCheck physicsCheck;
    public float normalSpeed;
    public float chaseSpeed;

    public float currentSpeed;
    public Vector3 faceDirct;
 
    protected void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        physicsCheck=GetComponent<PhysicsCheck>();
        currentSpeed=normalSpeed;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        faceDirct=new Vector3(-transform.localScale.x,0,0); //控制形象方向
        if(physicsCheck.touchLeftWall||physicsCheck.touchRightWall)
        {
            transform.localScale=new Vector3(faceDirct.x,1,1);
        }

    }

   
    protected virtual void FixedUpdate()  //让不同敌人的移动方式不同
    {
        EneymyMove();
    }

    public void EneymyMove()
    {
        rb.velocity=new Vector2(faceDirct.x*currentSpeed*Time.deltaTime,rb.velocity.y);
        anim.SetBool("Walk",true);
    }


}
