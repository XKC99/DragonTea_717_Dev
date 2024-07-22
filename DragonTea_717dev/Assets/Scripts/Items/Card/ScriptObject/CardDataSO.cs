using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataSO", menuName = "Card/CardDataSO")]

public class CardDataSO : ScriptableObject
{
   public string cardName;
   public Sprite cardImage;
   public CardType cardType;
   public int cardValue;
   public string description;

   //TODO:执行的实际效果



}
