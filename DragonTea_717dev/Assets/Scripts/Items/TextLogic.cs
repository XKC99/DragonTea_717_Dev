using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextLogic : ItemLogic
{
    public UnityEvent OnhitEvent;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Heal"))
        {
            // AudioManager.Instance.PlayOneShot("shealboom");
            // Debug.Log($"撞上了(自身:{gameObject.name}_{gameObject.GetInstanceID()};对方:{collision.gameObject.name}_{collision.gameObject.GetInstanceID()})");
            // SkillBallPool.Instance.PushBallObject(collision.gameObject);
            // Destroy(gameObject); // 击中火球后销毁
            HealBallEffect(collision);
        }
   
        
    }
 



    public void HealBallEffect(Collider2D collision)
    {
        DataManager.Instance.cleanNumber++;
        AudioManager.Instance.PlayOneShot("shealboom");
        Debug.Log($"撞上了(自身:{gameObject.name}_{gameObject.GetInstanceID()};对方:{collision.gameObject.name}_{collision.gameObject.GetInstanceID()})");
        SkillBallPool.Instance.PushBallObject(collision.gameObject);
        HitText();
    }

    public void HitText()
    {
        OnhitEvent?.Invoke();
    }
}
