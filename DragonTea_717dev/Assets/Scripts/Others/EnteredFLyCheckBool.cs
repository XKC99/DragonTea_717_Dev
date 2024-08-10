using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredFLyCheckBool : MonoBehaviour
{
    public void EnterFlyCheckArea()
   {
      DataManager.Instance.isEnteredCheckFlyarea = true;
   }

   public void ExitFlyCheckArea()
   {
      DataManager.Instance.isEnteredCheckFlyarea = false;
   }
}
