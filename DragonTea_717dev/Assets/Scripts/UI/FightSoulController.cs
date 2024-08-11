using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSoulController : MonoBehaviour
{
    public Button spawnButton;    // 生成圆球的按钮
    public GameObject ballPrefab; // 圆球预制件
    public Transform targetPoint; // 圆球移动的目标点
    public float duration = 2f;   // 动画持续时间

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnBall);
    }

    private void SpawnBall()
    {
        // 从按钮的位置生成圆球
        GameObject ball = Instantiate(ballPrefab, spawnButton.transform.position, Quaternion.identity);
        // 启动协程，处理圆球的旋转、缩放和移动
        StartCoroutine(AnimateBall(ball));
    }

    private IEnumerator AnimateBall(GameObject ball)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = ball.transform.localScale; // 初始缩放
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f); // 目标缩放大小
        Vector3 initialPosition = ball.transform.position; // 初始位置
        Vector3 targetPosition = targetPoint.position; // 目标位置

        while (elapsedTime < duration)
        {
            // 计算当前的进度
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // 线性插值位置
            ball.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            // 线性插值缩放
            ball.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            // 旋转球体
            ball.transform.Rotate(Vector3.forward, 360 * Time.deltaTime);

            yield return null;
        }

        // 确保最后的状态
        ball.transform.position = targetPosition;
        ball.transform.localScale = targetScale;
    }
}
