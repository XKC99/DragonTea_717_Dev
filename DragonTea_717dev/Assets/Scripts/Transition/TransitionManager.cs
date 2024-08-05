using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    private bool isFade;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    // 用于存储每个场景的玩家位置
    private Dictionary<string, Vector3> scenePlayerPositions = new Dictionary<string, Vector3>();

    public void Transition(string from, string to, GameObject player, bool preservePosition = true)
    {
        if (!isFade)
        {
            // 如果需要保留位置，保存当前玩家的位置
            if (preservePosition)
            {
                SavePlayerPosition(from, player.transform.position);
            }
            StartCoroutine(TransitionToScene(from, to, player, preservePosition));
        }
    }

    private IEnumerator TransitionToScene(string from, string to, GameObject player, bool preservePosition)
    {
        yield return Fade(1);

        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        // 设置新场景为激活场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        // 如果需要保留位置，则恢复玩家位置
        if (preservePosition)
        {
            RestorePlayerPosition(to, player);
        }

        yield return Fade(0);
    }

    private void SavePlayerPosition(string sceneName, Vector3 position)
    {
        if (scenePlayerPositions.ContainsKey(sceneName))
        {
            scenePlayerPositions[sceneName] = position;
        }
        else
        {
            scenePlayerPositions.Add(sceneName, position);
        }
    }

    private void RestorePlayerPosition(string sceneName, GameObject player)
    {
        if (scenePlayerPositions.ContainsKey(sceneName))
        {
            player.transform.position = scenePlayerPositions[sceneName];
        }
    }

    private IEnumerator Fade(float targetAlpha)
    {
        fadeCanvasGroup.alpha = 1 - targetAlpha;
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}
