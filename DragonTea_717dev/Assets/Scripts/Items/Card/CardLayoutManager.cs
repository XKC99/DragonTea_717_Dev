using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLayoutManager : MonoBehaviour
{
   public bool isHorizontal; //是横向排列还是扇形排列
   public float maxWidth=7f;//整套卡牌的最大宽度
   public float cardSpacing=2f;//每2张牌之间的间隙
   public float cardWidth;
   public Vector3 cardCenterPoint;
   
   [SerializeField]private List<Vector3> cardPositions=new();
   private List<Quaternion> cardRotations=new();

   public CardTranform GetCardTranform(int index,int cardTotal)
   {
        CalculatePosition(cardTotal,isHorizontal);
        return new CardTranform(cardPositions[index],cardRotations[index]);
   }


   public void CalculatePosition(int numbersOfCards,bool horizontal)
   {
        if (Camera.main == null) return;
        var pivot = Camera.main.transform.GetChild(0);

        cardPositions.Clear();
        cardRotations.Clear();

        if (horizontal)
        {
            float totalWidth = cardWidth * numbersOfCards + cardSpacing * (numbersOfCards - 1);
            // 假设卡牌的中心点位于水平中心
            for (int i = 0; i < numbersOfCards; ++i) {
                float xPos = i * cardWidth + i * cardSpacing + cardWidth / 2;
                xPos = pivot.position.x - totalWidth / 2 + xPos;
                cardPositions.Add(new Vector3(xPos, pivot.position.y, pivot.position.z));
                cardRotations.Add(Quaternion.identity);
            }

            //float currentWidth=cardSpacing*(numbersOfCards-1);
            //float totalWidth=Mathf.Min(currentWidth,maxWidth); //返回最小的那个值

        //     float currentSpacing=totalWidth>0?totalWidth/(numbersOfCards-1):0;

        //     for(int i=0;i<numbersOfCards;i++)
        //     {   
        //         float xPos=0-(totalWidth/2)+(i*currentSpacing);

        //         var pos=new Vector3(xPos,cardCenterPoint.y,0);
        //         var rotations=Quaternion.identity;

        //         cardPositions.Add(pos);
        //         cardRotations.Add(rotations);


        //     }
        }
   }






}
