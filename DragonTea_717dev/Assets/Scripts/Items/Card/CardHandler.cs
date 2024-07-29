using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour
{
    private Card currentCard;
    private SpriteRenderer spriteRenderer;
    private bool canMove;
    private bool isMoving;

    //private bool canExcute;//可以执行效果
    private ICardAffected cardAffected;
    private bool isUsed;//释放后执行了效果

    private void Awake() {
        currentCard=GetComponent<Card>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Input.GetMouseButtonUp(0)) 
            {
                 if (cardAffected != null && cardAffected.Execute(currentCard))
                 {
                    Debug.Log("卡牌生效");
                    isMoving = false;
                    isUsed=true;
                    cardAffected=null;
                    UseSelf();

                    // switch(currentCard.cardType)
                    // {
                    //     case CardType.Fire:
                    //         Debug.Log("攻击");
                    //         isMoving=false;
                    //         //canExcute=false;
                    //         cardAffected.Execute(currentCard);
                    //         isUsed=true;
                    //         UseSelf();
                    //         break;
                    //     case CardType.Heal:
                    //         Debug.Log("治疗");
                    //         isMoving=false;
                    //         //canExcute=false;
                    //         cardAffected.Execute(currentCard);
                    //         isUsed=true;
                    //         UseSelf();
                    //         break;
                    //     case CardType.Fly:
                    //         Debug.Log("飞行");
                    //         isMoving=false;
                    //         //canExcute=false;
                    //         cardAffected.Execute(currentCard);
                    //         isUsed=true;
                    //         UseSelf();
                    //         break;
                    //     case CardType.Fall:
                    //         Debug.Log("坠落");
                    //         isMoving=false;
                    //         //canExcute=false;
                    //         cardAffected.Execute(currentCard);
                    //         isUsed=true;
                    //         UseSelf();
                    //         break;
                    // }

                    //  Debug.Log("释放成功");//在这个地方添加释放判断。如果没放在正确的地方返回下面的方法。
                    //  isMoving=false;
                    //  canExcute=false;

                 }
                 else
                 {
                transform.localPosition = currentCard.localOffset;
                spriteRenderer.sortingOrder = 0;
                isMoving = false;
                 }
                
            }
            else
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = transform.position.z;
                transform.position = pos;
            }
        }
        else
        {
            if (canMove)
            {
                // 拖动卡牌
                if (Input.GetMouseButtonDown(0))
                {
                    isMoving = true;
                    spriteRenderer.sortingOrder = 1;
                }
                // 转换卡牌
                else if (Input.GetMouseButtonDown(1))
                {
                    currentCard.ChangeCard();
                }
            }
        }
    }


    private void OnMouseEnter() 
    {
        canMove = true;
    }

    private void OnMouseExit() 
    {
        canMove = false;
    }

    public void SetExcuteTure(ICardAffected ca)
    {
        //canExcute=true;

        // 已经有可被卡牌作用的对象就跳过，即只作用于第一个触发触发器的
        if (cardAffected != null) return;
        cardAffected = ca;
    }

    public void SetExcuteFalse(ICardAffected ca)
    {
        //canExcute=false;

        if (cardAffected != ca) return;
        cardAffected = null;
    }

    
    private void OnCollisionEnter2D(Collision2D other) 
    {
       
       if(isUsed)
       {
         if(other.gameObject.tag=="Box")
        {
            Debug.Log("Box消失吧");
            other.gameObject.SetActive(false);
            isUsed=false;

        }

       }
    }

    private void UseSelf() 
    {
        PoolTool.Instance.ReleaseObjectToPool(gameObject);
        CardDeck.Instance.RemoveHandCard(currentCard);
    }


    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     canMove=true;
    //     Debug.Log("OnBeginDrag");
    // }

    // public void OnDrag(PointerEventData eventData)
    // {
    //     if(canMove)
    //     {
    //         currentCard.isAnimating=true;
    //         Vector3 ScreenPos=new(Input.mousePosition.x,Input.mousePosition.y,15); //因为摄像机的z是-14
    //         Vector3 worldPos=Camera.main.ScreenToWorldPoint(ScreenPos);
    //         currentCard.transform.position=worldPos;
    //     }
    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     if(canExcute)  //或者碰撞检测
    //     {

    //     }
    //     else
    //     {
            
    //         currentCard.isAnimating=false;
    //     }
        


    // }

    
 
}