using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Item : MonoBehaviour
{
   public ItemName itemName;

   public void ItemGet()
   {
     //添加到背包后隐藏起来
     InventoryManager.Instance.AddItem(itemName);
     this.gameObject.SetActive(false);
   }
}
