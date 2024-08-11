using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoUICondition : MonoBehaviour
{
    public GameObject PlayUI;

    public List<GameObject> FalseEnemyList;
    public List<GameObject> TrueNPCList;

   public void CheckPlayButton()
   {
    if(DataManager.Instance.isGetOneMoreLife)
    {
        PlayUI.SetActive(true);
    }

   }

   public void SetFalseEnemy()
   {
    foreach(GameObject enemy in FalseEnemyList)
    {
        enemy.SetActive(false);
    }
   }

   public void SetTrueEnemy()
   {
    foreach(GameObject enemy in FalseEnemyList)
    {
        enemy.SetActive(true);
    }
   }


   public void SetTrueNPC()
   {
    foreach(GameObject npc in TrueNPCList)
    {
        npc.SetActive(true);
    }
   }

   public void SetFalseNPC()
   {
    foreach(GameObject npc in TrueNPCList)
    {
        npc.SetActive(false);
    }
   }
}
