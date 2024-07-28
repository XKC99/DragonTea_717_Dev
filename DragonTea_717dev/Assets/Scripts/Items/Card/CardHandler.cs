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

    private bool canExcute;//可以执行效果

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
                //在这个地方添加释放判断。如果没放在正确的地方返回下面的方法。
                transform.localPosition = currentCard.localOffset;
                spriteRenderer.sortingOrder = 0;
                isMoving = false;
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
            if (canMove && Input.GetMouseButtonDown(0))
            {
                isMoving = true;
                spriteRenderer.sortingOrder = 1;
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
