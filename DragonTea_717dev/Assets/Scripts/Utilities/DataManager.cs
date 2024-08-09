using System.Collections.Generic;
using UnityEngine;


public class SerializableData
{
   public bool active;
   public Vector3 position;
   public Quaternion rotation;
   public Vector3 scale;

   public override string ToString()
   {
      return $"{position},{rotation},{scale}.[{active}]";
   }
}

public class DataManager : Singleton<DataManager>
{
   public bool isPlayerDead;
   public int evilCount=0;//罪恶值
   public int killNumber=0;//杀害数
   public int healNumber=0;//治愈数
   public bool isEneteredMemory;//是否进入过记忆区域
   public bool isNotFirstDeadByEnemy;//不是第一次被敌人杀死

   public bool isFirstUseFly;  //第一次使用飞行牌
   public bool isEnteredCheckFlyarea; //是否进入了检查飞行区域
   public bool isFirstUseFall; //第一次使用坠落牌

   public DialogueSpeaker firstDeadByEnemySpeaker;


   private readonly Dictionary<int, Dictionary<int, SerializableData>> _saveDataDict = new();

   public void SaveData(DataSerializerBase serializerComp)
   {
      var seceneId = serializerComp.GetSceneId();
      
      if (!_saveDataDict.TryGetValue(seceneId, out var dict))
      {
         dict = new();
         _saveDataDict.Add(seceneId, dict);
      }

      var hashId = serializerComp.GetHashId();
      var data = serializerComp.Serialize();

      //Debug.Log("存档" + hashId);
      if (dict.ContainsKey(hashId))
      {
         dict[hashId] = data;
      }
      else
      {
         dict.Add(hashId, data);
      }
   }

   public void LoadData(DataSerializerBase serializerComp)
   {
      //Debug.Log("读档" + serializerComp.GetSceneId());
      if (_saveDataDict.TryGetValue(serializerComp.GetSceneId(), out var dict))
      {
         //Debug.Log("读档" + serializerComp.GetHashId());
         if (dict.TryGetValue(serializerComp.GetHashId(), out var data))
         {
            serializerComp.Deserialize(data);
         }
      }
   }

   public void EnterFlyCheckArea()
   {
      isEnteredCheckFlyarea = true;
   }

   public void ExitFlyCheckArea()
   {
      isEnteredCheckFlyarea = false;
   }
}
