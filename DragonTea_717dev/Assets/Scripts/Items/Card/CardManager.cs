using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class CardManager : Singleton<CardManager>
{
   public PoolTool poolTool;
   public List<CardDataSO> cardDataSOList; //游戏中所有可能出现的卡牌

   [Header("玩家手牌")]
   public CardLibrarySO currentPlayerLibrary;

   public GameObject GetCardObject()
   {
      return poolTool.GetObjectFromPool();
   }

   public void DiscardCard(GameObject card)
   {
      poolTool.ReleaseObjectToPool(card);
   }

   public void DrawCard()
   {
      //从玩家牌库里随机抽一张牌
      //CardDataSO cardData = currentPlayerLibrary.cardLibraryList[UnityEngine.Random.Range(0, currentPlayerLibrary.cardLibraryList.Count)].cardData;
      /*
      GameObject card = poolTool.GetObjectFromPool();
      card.GetComponent<Card>().InitCard(cardData);*/
   }

   //下面没啥必要
   // private void InitCardList()
   // {
   //    Addressables.LoadAssetsAsync<CardDataSO>("CardData",null).Completed += OnCardDataLoaded;
   // }

   //  private void OnCardDataLoaded(AsyncOperationHandle<IList<CardDataSO>> handle)
   //  {
   //    if(handle.Status == AsyncOperationStatus.Succeeded)
   //    {
   //       cardDataSOList = new List<CardDataSO>(handle.Result);

   //    }
   //    else{
   //       Debug.LogError("加载卡牌数据失败");

   //    }
   //  }

        
}
