using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class CardDeck : Singleton<CardDeck>

{
    public CardManager cardManager;

    public CardLayoutManager cardLayoutManager;

    private List<CardDataSO> drawDeck=new(); //抽牌堆
    private List<CardDataSO> discardDeck=new(); //弃牌堆

    [SerializeField]private List<Card> handCardObjects=new(); //当前手牌


    public void InitCardDeck()
    {

    }

    public void DrawCard(Card card)
    {
        handCardObjects.Add(card);
    }

    public void SetCardLayOut()
    {
        for(int i=0;i<handCardObjects.Count;i++)
        {
            Card currentCard=handCardObjects[i];
            CardTranform cardTranform=cardLayoutManager.GetCardTranform(i,handCardObjects.Count);

            var pivot = Camera.main.transform.GetChild(0);
            currentCard.transform.SetParent(pivot);
            currentCard.transform.SetPositionAndRotation(cardTranform.pos,cardTranform.rotation);
            currentCard.RefreshOffset();
        }
    }

    public void RemoveHandCard(Card card) 
    {
        handCardObjects.Remove(card);
        SetCardLayOut();
    }





}
