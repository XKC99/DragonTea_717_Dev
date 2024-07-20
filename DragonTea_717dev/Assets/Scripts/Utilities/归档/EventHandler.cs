using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler  //事件控制中心
{
   public static event Action BoxCollision;  //盒子碰撞事件。事件命名方法。
   public static void CallBoxOnCollision() //用于触发盒子碰撞事件。当有方法订阅该事件时，会调用订阅的方法
   { 
    //运行CallBoxONCollision后如果存在OnBoxCollision事件，则调用OnBoxCollision事件。
      BoxCollision?.Invoke();
   }

   public static event Action TimelineCollision;
   public static void CallTimelineOnCollision()
   {
      TimelineCollision?.Invoke();
   }

   public static event Action<GameObject> SpeakerCollision;
   public static void CallSpeakerCollision(GameObject colliderGo)
   {
      SpeakerCollision?.Invoke(colliderGo);
   }

   public static event Action TransToAnotherSecne;
   public static void CallTransToAnotherSecne()
   {
      TransToAnotherSecne?.Invoke();
   }

  


}
