using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : ItemLogic,ICardAffected 
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Fire")
      {
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

    
}
