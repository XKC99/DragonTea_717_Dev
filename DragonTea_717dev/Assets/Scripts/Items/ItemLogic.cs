using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour,IFireHitandHeal  //接口命名往往以I开头
{
    protected virtual void OnCollider(string AudioName)
    {
        
    }

   protected virtual void OnFirehaha()
   {
      Debug.Log("OnFire-我被火球打到了！");
   }

   public virtual void OnFire()  //这里是接口提供的方法，需要实现
   {
    Debug.Log("我被击中了");

   }

    public void OnHeal()//这里是接口提供的方法，需要实现
    {
       Debug.Log("我被治疗了");
    }
}
