using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    [HideInInspector]public CanvasGroup canvasGroup;
    public float fadeSpeed = 5f;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
       //FadeIn();
    }

   public void FadeIn()
{
    if (canvasGroup.alpha < 1)
    {
        //Debug.Log("haohaohao");
        canvasGroup.alpha +=fadeSpeed*Time.deltaTime;
        Debug.Log("haohaohao");//这个输出了，但是没有显示出来，奇怪
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}

    public void FadeOut()
{
    if (canvasGroup.alpha > 0)
    {
        canvasGroup.alpha-=fadeSpeed*Time.deltaTime;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
}
