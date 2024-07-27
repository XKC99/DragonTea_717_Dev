using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class CardManager : MonoBehaviour
{
   public PoolTool poolTool;
   public List<CardDataSO> cardDataSOList; //游戏中所有可能出现的卡牌

   private void InitCardList()
   {
      Addressables.LoadAssetsAsync<CardDataSO>("CardData",null).Completed += OnCardDataLoaded;
   }

    private void OnCardDataLoaded(AsyncOperationHandle<IList<CardDataSO>> handle)
    {
      if(handle.Status == AsyncOperationStatus.Succeeded)
      {
         cardDataSOList = new List<CardDataSO>(handle.Result);

      }
      else{
         Debug.LogError("加载卡牌数据失败");

      }
    }

        
}
