using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeSpeed = 5f;
    private bool isFade=false;

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
        canvasGroup.alpha = Mathf.Min(canvasGroup.alpha + fadeSpeed * Time.deltaTime, 1);
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}

    public void FadeOut()
{
    if (canvasGroup.alpha > 0)
    {
        canvasGroup.alpha = Mathf.Max(canvasGroup.alpha - fadeSpeed * Time.deltaTime, 0);
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
}
