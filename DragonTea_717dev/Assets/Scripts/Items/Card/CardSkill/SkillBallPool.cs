using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class SkillBallPool:Singleton<SkillBallPool>
{
   private Dictionary<string,Queue<GameObject>> skillBallPool = new Dictionary<string, Queue<GameObject>>();
   private GameObject poll;

    public GameObject GetBallObject(GameObject ballPrefab)
   {
        GameObject gameObject;
        if (skillBallPool.ContainsKey(ballPrefab.name)) {
            Debug.Log($"Temp: GetBallObject Count:{skillBallPool[ballPrefab.name].Count}");
        }

        ballDestroyed:
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

        Debug.Log($"Temp: GetBallObject_BeforeDequeue({skillBallPool[ballPrefab.name].Peek() != null}) Count:{skillBallPool[ballPrefab.name].Count}");
        while (true) 
        {
            gameObject=skillBallPool[ballPrefab.name].Dequeue();
            if (gameObject != null) break;
            if (skillBallPool[ballPrefab.name].Count == 0)
            {
                goto ballDestroyed;
            }
        }
        Debug.Log($"Temp: GetBallObject_AfterDequeue({gameObject != null}) Count:{skillBallPool[ballPrefab.name].Count}");
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
        if (!skillBallPool[_name].Contains(ballPrefab)) 
        {
            skillBallPool[_name].Enqueue(ballPrefab);
        }
        Debug.Log($"Temp: PushBallObject_PoolEnqueue({ballPrefab != null}) Count:{skillBallPool[_name].Count}");
        ballPrefab.SetActive(false);

   }



}
