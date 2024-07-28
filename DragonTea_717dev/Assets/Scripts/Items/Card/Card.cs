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

    internal Vector3 localOffset;

    private void Start()
    {
        InitCard(cardData);
    }

    public void InitCard(CardDataSO data)
    {
        cardData = data;
        cardType = data.cardType;
        cardSprite.sprite = data.cardImage;
        //cardDescription.text = data.description;
        cardValue = data.cardValue;
        
    }
    
    public void RefreshOffset()
    {
        localOffset = transform.localPosition;
    }
}
