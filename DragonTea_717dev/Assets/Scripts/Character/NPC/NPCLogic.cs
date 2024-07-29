using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : ItemLogic,ICardAffected 
{
     private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Fire")
      {
          OnFire();
          Destroy(other.gameObject);
          this.gameObject.SetActive(false);
      }
      if(other.gameObject.tag == "Heal")
      {
        Debug.Log("我被治愈了");
      }

      if(other.gameObject.tag == "Card")
      {
        other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
        Debug.Log("发现卡牌");
      }

    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Card")
        {
            other.gameObject.GetComponent<CardHandler>().SetExcuteFalse(this);
            //Debug.Log("离开卡牌");--实际功能
        }
    }
}
