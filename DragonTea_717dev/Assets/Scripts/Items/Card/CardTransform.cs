using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardTranform 
{
   public Vector3 pos;
   public Quaternion rotation;

   public CardTranform(Vector3 cardPos,Quaternion cardRotation)
   {
        pos=cardPos;
        rotation=cardRotation;

   }


}
