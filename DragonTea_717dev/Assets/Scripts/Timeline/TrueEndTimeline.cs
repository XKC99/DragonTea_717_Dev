using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEndTimeline : MonoBehaviour
{
    public List<GameObject> theTrueThing;
    public List<GameObject> theFalseThing;
   public void theTimelineTrue()
   {
        for(int i=0;i<theTrueThing.Count;i++)
        {
            theTrueThing[i].SetActive(true);
        }
        for(int j=0;j<theFalseThing.Count;j++)
        {
            theFalseThing[j].SetActive(false);
        }
   }
}
