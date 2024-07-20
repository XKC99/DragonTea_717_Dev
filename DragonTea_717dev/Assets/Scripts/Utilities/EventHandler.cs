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

  


}
