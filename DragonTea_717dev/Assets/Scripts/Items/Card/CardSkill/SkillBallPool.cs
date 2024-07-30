using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SkillBallPool:Singleton<SkillBallPool>
{
   private Dictionary<string,Queue<GameObject>> skillBallPool = new Dictionary<string, Queue<GameObject>>();
   private GameObject poll;

   public GameObject GetBallObject(GameObject ballPrefab)
   {
      GameObject gameObject;
      if(!skillBallPool.ContainsKey(ballPrefab.name)||skillBallPool[ballPrefab.name].Count==0)
      {
        gameObject=GameObject.Instantiate(ballPrefab);
        PushBallObject(gameObject);
        if(poll==null)
        {
            poll=new GameObject("SkillBallPool");
        }
        GameObject childPool=GameObject.Find(ballPrefab.name+"Pool");
        if(!childPool)
        {
            childPool=new GameObject(ballPrefab.name+"Pool");
            childPool.transform.SetParent(poll.transform);
        }
         gameObject.transform.SetParent(childPool.transform);

      }
      gameObject=skillBallPool[ballPrefab.name].Dequeue();
      gameObject.SetActive(true);
      return gameObject;
     
   }

   public void PushBallObject(GameObject ballPrefab)
   {    
        string _name=ballPrefab.name.Replace("(Clone)",string.Empty);
        if(!skillBallPool.ContainsKey(_name))
        {
            skillBallPool.Add(_name,new Queue<GameObject>());
        }
        skillBallPool[_name].Enqueue(ballPrefab);
        ballPrefab.SetActive(false);

   }



}
