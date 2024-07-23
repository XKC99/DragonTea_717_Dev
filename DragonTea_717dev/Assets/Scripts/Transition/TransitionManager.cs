using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
  private bool isFade;
  public CanvasGroup fadeCanvasGroup;
  public float fadeDuration;
  public void Transition(string from,string to)
  {
    if(!isFade)
    {
      StartCoroutine(TransitionToScene(from,to));
    }
  }

  private IEnumerator TransitionToScene(string from,string to)
  {
    yield return Fade(1);
    yield return SceneManager.UnloadSceneAsync(from);
    yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);

    //设置新场景为激活场景
    Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
    SceneManager.SetActiveScene(newScene);

    yield return Fade(0);
  }

  private IEnumerable Fade(float targetAlpha)
  {
    isFade = true;
    fadeCanvasGroup.blocksRaycasts = true;
    float speed=Mathf.Abs(fadeCanvasGroup.alpha-targetAlpha)/fadeDuration;
    while(!Mathf.Approximately(fadeCanvasGroup.alpha,targetAlpha))
    {
      fadeCanvasGroup.alpha=Mathf.MoveTowards(fadeCanvasGroup.alpha,targetAlpha,speed*Time.deltaTime);
      yield return null;
    }
    fadeCanvasGroup.blocksRaycasts = false;
    isFade = false;

  }
}
