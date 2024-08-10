using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public float timeLimit = 10.0f;  // 规定的时间限制
    private float timer;  // 当前的计时器
    private bool isTiming;  // 计时器是否在运行
    private bool playerInTargetArea;  // 玩家是否到达目标区域
    public List<DialogueSpeaker> wiatDialogueSpeakers;

    private void Start()
    {
        // 初始化列表
        wiatDialogueSpeakers = new List<DialogueSpeaker>();

        // 获取当前物体的所有子物体中的DialogueSpeaker组件
        foreach (Transform child in transform)
        {
            DialogueSpeaker dialogueSpeaker = child.GetComponent<DialogueSpeaker>();
            if (dialogueSpeaker != null)
            {
                wiatDialogueSpeakers.Add(dialogueSpeaker);
            }
        }
    }

    // 当玩家进入开始触发器时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isTiming)
            {
                StartTimer();
            }
        }
    }

    // 更新计时器
    private void Update()
    {
        if (isTiming)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isTiming = false;

                if (!playerInTargetArea)
                {
                    int index = Random.Range(0, wiatDialogueSpeakers.Count);
                    wiatDialogueSpeakers[index].Play();
                    ResetTimer();  // 在播放完成后重置并重新开始计时
                }
            }
        }
    }

    // 开始计时器
    private void StartTimer()
    {
        timer = timeLimit;
        isTiming = true;
        playerInTargetArea = false;
        Debug.Log("Timer started!");
    }

    // 重置计时器并重新开始
    private void ResetTimer()
    {
        StartTimer();  // 重新开始计时
    }

    // 当玩家到达目标区域时调用
    public void PlayerReachedTarget()
    {
        if (isTiming)
        {
            playerInTargetArea = true;
            isTiming = false;
            Debug.Log("Player reached the target area in time!");
        }
    }
}
