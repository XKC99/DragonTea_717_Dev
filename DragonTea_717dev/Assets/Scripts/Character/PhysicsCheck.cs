using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private CapsuleCollider2D collider;

    [Header("检测参数")]
    public bool manual;//选择是否自动设置检测点.false为自动设置检测点
    public Vector2 bottomOffset; // 脚底的位移差值
    public Vector2 leftOff; // 左侧的位移差值
    public Vector2 rightOff;// 右侧的位移差值
    public float checkRadius=0.1f;
    public LayerMask groundLayer;
    [Header("状态")]
    public bool isGround;
    public bool touchLeftWall;
    public bool touchRightWall;
    
  
    private void Awake()
    {
        collider=GetComponent<CapsuleCollider2D>();
        if(!manual)
        {
            rightOff=new Vector2((collider.bounds.size.x+collider.offset.x)/2,collider.bounds.size.y/2);
            leftOff=new Vector2(-rightOff.x,rightOff.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    public void Check()
    {
        //检测地面
        isGround=Physics2D.OverlapCircle((Vector2)transform.position+bottomOffset, checkRadius,groundLayer);
        //墙体判断
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOff, checkRadius, groundLayer);
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOff, checkRadius, groundLayer);
    }

   
    private void OnDrawGizmosSelected()  //方便查看检测范围
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOff, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOff, checkRadius);
    }
}
