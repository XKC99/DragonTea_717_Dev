using System.Collections;
using System.Collections.Generic;
using ParadoxNotion;
using Unity.VisualScripting;
using UnityEngine;



public class MoveObject : MonoBehaviour
{
    public float speed = 1f;
    public float waitTime=0.5f;
    public Transform[] movePos;
    public LayerMask moveTogetherLayer;

    private BoxCollider2D coll;

    private int i;
    private bool isRise;
    private readonly List<GameObject> moveTogetherGos = new();
    private readonly List<Vector2> moveGoRelativePosList = new();


    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        i=1;
        isRise=true;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.IsInLayerMask(moveTogetherLayer) && !moveTogetherGos.Contains(other.gameObject)) {
            moveTogetherGos.Add(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.IsInLayerMask(moveTogetherLayer) && moveTogetherGos.Contains(other.gameObject)) {
            moveTogetherGos.Remove(other.gameObject);
        }
    }


    void Update()
    {
        moveGoRelativePosList.Clear();
        foreach (var item in moveTogetherGos) {
            moveGoRelativePosList.Add(item.transform.position-transform.position);
        }

        transform.localPosition=Vector2.MoveTowards(transform.localPosition, movePos[i].localPosition, speed * Time.deltaTime);
        if(Vector2.Distance(transform.localPosition, movePos[i].localPosition)<0.1f)
        {
            if(waitTime<0)
            {
                if (isRise) {
                    if (i == movePos.Length - 1) {
                        isRise = false;
                        --i;
                    }
                    else {
                        ++i;
                    }
                }
                else {
                    if (i == 0) {
                        isRise = true;
                        ++i;
                    }
                    else {
                        --i;
                    }
                }
                waitTime=0.5f;
            }
            else
            {
                waitTime-=Time.deltaTime;
            }
        }

        Vector2 temp = Vector2.zero;
        for (int i = 0; i < moveTogetherGos.Count; i++)
        {
            var item = moveTogetherGos[i];
            if (!IsOnSelf(item.transform.position)) continue;
            var rbComp = item.GetComponent<Rigidbody2D>();
            if (rbComp.velocity!=Vector2.zero) continue;

            temp.x = transform.position.x + moveGoRelativePosList[i].x;
            temp.y = transform.position.y + moveGoRelativePosList[i].y;

            item.transform.position=temp;
        }
    }

    private bool IsOnSelf(Vector2 pos) 
    {
        return pos.y >= transform.position.y + coll.offset.y &&
               pos.x >= transform.position.x + coll.offset.x - coll.size.x / 2 &&
               pos.x <= transform.position.x + coll.offset.x + coll.size.x / 2;
    }
}