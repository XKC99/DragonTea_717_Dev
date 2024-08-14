using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private DialogueSpeaker currentSpeaker;
    [Header("转换触发语音")]
    public float speakerPlayChance;  //播放概率
    public List<DialogueSpeaker> changeToFireSpeakers;
    public List<DialogueSpeaker> changeToHealSpeakers;
    public List<DialogueSpeaker> changeToFlySpeakers;
    public List<DialogueSpeaker> changeToFallSpeakers;
    [Header("箱子飞触发语音")]
    public DialogueSpeaker boxFirstFly;
    public List<DialogueSpeaker> boxFlySpeakers;

    [Header("其他东西落触发语音")]
    public List<DialogueSpeaker> otherFallSpeakers;
    
    [Header("玩家飞触发语音")]
    public DialogueSpeaker firstFlyAndWrongSpeaker; //第一次飞且在监测区域（不希望飞）
    public List<DialogueSpeaker> playerFlySpeakers;

    [Header("玩家地面用降落语音")]
    public DialogueSpeaker firstFallAndOnGroundSpeaker; //第一次地面用降落牌，且在监测区域
    public DialogueSpeaker normalFallAndOnGroundSpeaker; //地面用降落牌
    public List<DialogueSpeaker> playerFallSpeakers;

    [Header("对敌人操作")]
    public List<DialogueSpeaker> fireToEnemSpeakers;
    public List<DialogueSpeaker> healToEnemSpeakers;

    public DialogueSpeaker enemyFirstFly;
    public List<DialogueSpeaker> flyToEnemSpeakers;
    [Header("玩家第一次加速语音")]
    public DialogueSpeaker firstSpeedUpSpeaker;
    [Header("第一次破坏文本语音")]
    public DialogueSpeaker firstDamageText;
    [Header("第一次碰到世界边界")]
    public DialogueSpeaker firstOnEdge;
    [Header("第一次删除卡牌")]
    public DialogueSpeaker firstDelete;


    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDialogue(DialogueSpeaker speaker)
    {
        if (currentSpeaker != null && currentSpeaker != speaker)
        {
            currentSpeaker.Interrupt();
        }
        currentSpeaker = speaker;
    }

    public void ClearCurrentSpeaker(DialogueSpeaker speaker)
    {
        if (currentSpeaker == speaker)
        {
            currentSpeaker = null;
        }
    }

    public void PlaySpeedUp()
    {
        firstSpeedUpSpeaker.Play();
    }

    public void PlayRandomDialogue(int i)
    {
        speakerPlayChance=0.6f;
        if(DataManager.Instance.isInSilentArea)
        {
            return;
        }
        switch (i)
        {
            case 1:
            if(changeToFireSpeakers.Count > 0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, changeToFireSpeakers.Count);
                changeToFireSpeakers[index].Play();
            }
            break;
            case 2:
            if(changeToHealSpeakers.Count > 0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, changeToHealSpeakers.Count);
                changeToHealSpeakers[index].Play();
            }
            break;
            case 3:
            if(changeToFlySpeakers.Count > 0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, changeToFlySpeakers.Count);
                changeToFlySpeakers[index].Play();
            }
            break;
            case 4:
             if(changeToFallSpeakers.Count > 0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, changeToFallSpeakers.Count);
                changeToFallSpeakers[index].Play();
            }
            break;
            case 5:  //箱子飞起来
            if(boxFlySpeakers.Count > 0)
            {
                if(DataManager.Instance.isBoxFirstFly)
                {
                    Debug.Log("第一次飞箱子");
                    boxFirstFly.Play();
                }
                else
                {
                int index=Random.Range(0, boxFlySpeakers.Count);
                boxFlySpeakers[index].Play();
                }
            }
            break;
            case 6://敌人飞起来
            if(flyToEnemSpeakers.Count>0)
            {
                if(DataManager.Instance.isEnemyFirstFly)
                {
                    enemyFirstFly.Play();
                }
                else
                {
                    int index=Random.Range(0, flyToEnemSpeakers.Count);
                    flyToEnemSpeakers[index].Play();
                }
            }
            break;
            case 7://对其他用降落
            if(otherFallSpeakers.Count>0)
            {
                int index=Random.Range(0, otherFallSpeakers.Count);
                otherFallSpeakers[index].Play();
            }
            break;
            case 8: //玩家飞
            if(playerFlySpeakers.Count>0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, playerFlySpeakers.Count);
                playerFlySpeakers[index].Play();
            }
            break;
            case 9: //玩家下降时用坠落
            if(playerFallSpeakers.Count>0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, playerFallSpeakers.Count);
                playerFallSpeakers[index].Play();
            }
            break;
            case 10: //对怪物用火
            if(fireToEnemSpeakers.Count>0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, fireToEnemSpeakers.Count);
                fireToEnemSpeakers[index].Play();
            }
            break;
            case 11:
            if(healToEnemSpeakers.Count>0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, healToEnemSpeakers.Count);
                healToEnemSpeakers[index].Play();
            }
            break;

        }
    }
}
