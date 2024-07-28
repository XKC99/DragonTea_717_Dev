using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    [Header("组件")]
    public SpriteRenderer cardSprite;
    public TextMeshPro cardDescription;
    public int cardValue;
    public CardType cardType;

    [Header("原始数据")]
    public Vector3 originalPosition;
    public Quaternion originalRotation;
    public int originalLayerOrder;

    public bool isAnimating;
    public CardDataSO cardData;
    public CardType initCardType;
    public List<CardDataSO> cardConfigList;

    internal Vector3 localOffset;

    private void Start()
    {
        //InitCard(cardData);
        InitCard(cardData);
    }

    private void OnDestroy() 
    {
        CardDeck.Instance.RemoveHandCard(this);
    }

    public void InitCard(CardDataSO data)
    {
        cardData = data;
        cardType = data.cardType;
        cardSprite.sprite = data.cardImage;
        //cardDescription.text = data.description;
        cardValue = data.cardValue;
    }

    public void ChangeCardType(CardType type) 
    {
        foreach (var data in cardConfigList)
        {
            if (data.cardType != type) continue;
            cardData = data;
            cardType = data.cardType;
            cardSprite.sprite = data.cardImage;
            //cardDescription.text = data.description;
            cardValue = data.cardValue;
        }
    }
    
    public void RefreshOffset()
    {
        localOffset = transform.localPosition;
    }

    public void ChangeCard()
    {
        Debug.Log("卡牌转换");
        switch (cardType)
        {
            case CardType.Fire:
            ChangeCardType(CardType.Heal);
            break;
            case CardType.Heal:
            ChangeCardType(CardType.Fire);
            break;
            case CardType.Fly:
            ChangeCardType(CardType.Fall);
            break;
            case CardType.Fall:
            ChangeCardType(CardType.Fly);
            break;
        }

    }
}
