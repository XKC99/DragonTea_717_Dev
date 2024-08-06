using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardTrigger : MonoBehaviour
{
   public CardDataSO cardData;

   [HideInInspector]public bool isGot;

   [HideInInspector]public int GotTimes=0;   
   // private void OnTriggerEnter2D(Collider2D other)
   // {
   //   if(other.CompareTag("Player"))
   //   {
   //      PlayerGetCard();
   //   }

   // }
   public UnityEvent CardTriggerEvent;

   private void Update() {
      if(GotTimes==1&&isGot)
      {
         OnTriggerPlayerWhenGotCard();
      }
   }

   public void PlayerGetCard()
   {
       //GameObject card=PoolTool.Instance.GetObjectFromPool();
        //GameObject card=CardManager.Instance.GetCardObject();
      if(CardDeck.Instance.handCardObjects.Count<=4)
      {
         GameObject card=PoolTool.Instance.GetObjectFromPool();
        card.GetComponent<Card>().InitCard(cardData);   
        CardDeck.Instance.DrawCard(card.GetComponent<Card>());
        CardDeck.Instance.SetCardLayOut();
      }
      else
      {
         CardDeck.Instance.HandCardFull();
      }
      //    GameObject card=PoolTool.Instance.GetObjectFromPool();
      //   //GameObject card=CardManager.Instance.GetCardObject();
      //   card.GetComponent<Card>().InitCard(cardData);   
      //   CardDeck.Instance.DrawCard(card.GetComponent<Card>());
      //   CardDeck.Instance.SetCardLayOut();

   }

   public void CardIsGot()
   {
      isGot=true;
   }

   public void GotTimesAdd()
   {
      GotTimes++;
   }

   public void SetFalse()
   {
      isGot=false;
   }

    public void OnTriggerPlayerWhenGotCard()   //第一次拿到卡时触发的事件
    {
        Debug.Log($"Trigger触发:{gameObject.name}");
        CardTriggerEvent?.Invoke();
    }



}
