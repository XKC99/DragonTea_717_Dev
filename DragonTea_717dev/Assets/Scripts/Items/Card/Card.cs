using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header(header:"组件")]
    public SpriteRenderer cardSprite;
    public TextMeshPro cardDescription;
    public int cardValue;
    public CardType cardType;


    public CardDataSO cardData;

    private void Start()
    {
        InitCard(cardData);
    }

    public void InitCard(CardDataSO data)
    {
        cardData = data;
        cardType = data.cardType;
        cardSprite.sprite = data.cardImage;
        cardDescription.text = data.description;
        cardValue = data.cardValue;
        

    }

}
