using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    [HideInInspector]public CanvasGroup canvasGroup;
    public float fadeSpeed = 5f;

    private int _fadeState;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
       //FadeIn();

        if (_fadeState == 1) {
            InternalFadeIn();
        }
        else if (_fadeState == -1) {
            InternalFadeOut();
        }
    }

   public void FadeIn()
    {   
        _fadeState = 1;
    }   

    public void FadeOut()
    {
        _fadeState = -1;
    }

    private void InternalFadeIn()
    {
        canvasGroup.alpha +=fadeSpeed*Time.deltaTime;

        if (canvasGroup.alpha >= 1) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            _fadeState = 0;
        }

        // if (canvasGroup.alpha < 1)
        // {
        //     //Debug.Log("haohaohao");
        //     canvasGroup.alpha +=fadeSpeed*Time.deltaTime;
        //     Debug.Log("haohaohao");//这个输出了，但是没有显示出来，奇怪
        //     canvasGroup.interactable = true;
        //     canvasGroup.blocksRaycasts = true;
        // }
    }

    private void InternalFadeOut()
    {
        canvasGroup.alpha-=fadeSpeed*Time.deltaTime;

        if (canvasGroup.alpha <= 0) {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            _fadeState = 0;
        }

        // if (canvasGroup.alpha > 0)
        // {
        //     canvasGroup.alpha-=fadeSpeed*Time.deltaTime;
        //     canvasGroup.interactable = false;
        //     canvasGroup.blocksRaycasts = false;
        // }
    }

    
}
