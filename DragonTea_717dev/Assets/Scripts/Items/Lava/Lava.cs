using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("撞上了");
            collision.GetComponent<DragonController>().DragonAttackedByLava();
            Destroy(gameObject); // 击中玩家后销毁子弹
        }
        if(collision.CompareTag("Fire"))
        {
            Debug.Log("撞上了");
            SkillBallPool.Instance.PushBallObject(collision.gameObject);
            Destroy(gameObject); // 击中火球后销毁
        }
    }
}
