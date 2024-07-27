using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLayoutManager : MonoBehaviour
{
   public bool isHorizontal; //是横向排列还是扇形排列
   public float maxWidth=7f;//整套卡牌的最大宽度
   public float cardSpacing=2f;//每2张牌之间的间隙
   public Vector3 cardCenterPoint;
   

   private List<Vector3> cardPositions=new();
   private List<Quaternion> cardRotations=new();

   public CardTranform GetCardTranform(int index,int cardTotal)
   {
        CalculatePosition(cardTotal,isHorizontal);
        return new CardTranform(cardPositions[index],cardRotations[index]);

   }


   private void CalculatePosition(int numbersOfCards,bool horizontal)
   {
    cardPositions.Clear();
    cardRotations.Clear();
        if (horizontal)
        {
            float currentWidth=cardSpacing*(numbersOfCards-1);
            float totalWidth=Mathf.Min(currentWidth,maxWidth); //返回最小的那个值

            float currentSpacing=totalWidth>0?totalWidth/(numbersOfCards-1):0;

            for(int i=0;i<numbersOfCards;i++)
            {   
                float xPos=0-(totalWidth/2)+(i*currentSpacing);

                var pos=new Vector3(xPos,cardCenterPoint.y,0);
                var rotations=Quaternion.identity;

                cardPositions.Add(pos);
                cardRotations.Add(rotations);


            }
        }
   }






}
