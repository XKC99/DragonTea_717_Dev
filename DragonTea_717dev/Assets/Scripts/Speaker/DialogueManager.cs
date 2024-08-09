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
    public List<DialogueSpeaker> boxFlySpeakers;
    
    [Header("玩家飞触发语音")]
    public DialogueSpeaker firstFlyAndWrongSpeaker; //第一次飞且在监测区域（不希望飞）
    public List<DialogueSpeaker> playerFlySpeakers;
    

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

    public void PlayRandomDialogue(int i)
    {
        speakerPlayChance=0.6f;
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
                int index=Random.Range(0, boxFlySpeakers.Count);
                boxFlySpeakers[index].Play();
            }
            break;
            case 7://箱子落下
            break;
            case 8:
            if(playerFlySpeakers.Count>0&&Random.value<=speakerPlayChance)
            {
                int index=Random.Range(0, playerFlySpeakers.Count);
                playerFlySpeakers[index].Play();
            }
            break;


        }
    }
}
