using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTrigger : MonoBehaviour
{
   public CardDataSO cardData;

   public bool isGot;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
     if(other.CompareTag("Player"))
     {
        PlayerGetCard();
     }

   }

   public void PlayerGetCard()
   {
         GameObject card=PoolTool.Instance.GetObjectFromPool();
        //GameObject card=CardManager.Instance.GetCardObject();
        card.GetComponent<Card>().InitCard(cardData);   
        CardDeck.Instance.DrawCard(card.GetComponent<Card>());
        CardDeck.Instance.SetCardLayOut();

   }
}
