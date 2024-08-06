using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsLogic : ItemLogic,ICardAffected 
{
    public override bool Execute(Card card) 
    {
        switch(card.cardType)
        {
            // case CardType.Fire:
            //     FireCardEffect();
            //     return true;
            // //  case CardType.Heal:
            // //     HealCardEffect();
            // //     return true;  //如果不想让这类牌发挥作用，返回false或者直接注释
             case CardType.Fly:
                FlyCardEffect();
                return true;
            case CardType.Fall:
                FallCardEffect();
                return true;
        }
        return false;
    }

    public override void FlyCardEffect()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        // this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+0.5f,this.transform.position.z);
        StartMovingUp();
    }

    public override void FallCardEffect()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator MoveUpSmoothly()
    {
        float startTime = Time.time;
        Vector3 startPosition = this.transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + 0.5f, startPosition.z);

        while (Time.time < startTime + 1.0f)
        {
            float t = (Time.time - startTime) / 1.0f; // 计算当前时间相对于总时间的比例
            this.transform.position = Vector3.Lerp(startPosition, endPosition, t); // 平滑移动
            yield return null; // 等待下一帧
        }

        this.transform.position = endPosition; // 确保最终位置准确无误
    }

    // 调用此方法以启动移动
    void StartMovingUp()
    {
        StartCoroutine(MoveUpSmoothly());
    }

    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag=="Ground")
    //     {
    //         rb.bodyType = RigidbodyType2D.Kinematic;
    //     }
    // }

}
