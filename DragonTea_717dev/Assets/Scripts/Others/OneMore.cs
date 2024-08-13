using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMore : MonoBehaviour
{
   public GameObject oneMoreNote;

   private void OnTriggerEnter2D()
   {
    oneMoreNote.SetActive(true);
    DataManager.Instance.isGetOneMoreLife = true;
   }

   private void OnTriggerExit2D()
   {
    oneMoreNote.SetActive(false);
   }
}
