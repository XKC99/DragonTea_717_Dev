using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKillNumber : MonoBehaviour
{
    [Header("图片")]
    public GameObject killNumberImage;
    public Texture kill1;
    public Texture kill2;
    public Texture kill3;
    public Texture kill4;
    public Texture kill5;
    public Texture kill6;

    [Header("杀与治后的语音")]
    public DialogueSpeaker sp2101;
    public DialogueSpeaker sp2102;
    public DialogueSpeaker sp2103;
    public DialogueSpeaker sp2104;
    public DialogueSpeaker sp2201;
    public DialogueSpeaker sp2202;
    public DialogueSpeaker sp2203;
    public DialogueSpeaker sp2204;

    [Header("治疗后对话完的语音")]
    
    public DialogueSpeaker sp2301;
    public DialogueSpeaker sp2302;
    public DialogueSpeaker sp2303;
    public DialogueSpeaker sp2304;




    private void Update() {
        ShowKillNumberImage();
        // SpeakerPlay();
    }
    public void ShowKillNumberImage()
    {
        if(DataManager.Instance.killNumber==0)
        {
            killNumberImage.SetActive(false);
        }
        else if(DataManager.Instance.killNumber>0)
        {
            killNumberImage.SetActive(true);
        }
        
        if(DataManager.Instance.killNumber==1)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill1;
        }
        if(DataManager.Instance.killNumber==2)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill2;
        }
        if(DataManager.Instance.killNumber==3)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill3;
        }
        if(DataManager.Instance.killNumber==4)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill4;
        }
        if(DataManager.Instance.killNumber==5)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill5;
        }
        if(DataManager.Instance.killNumber==6)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill6;
        }
    }

    public void SpeakerKillPlay()
    {
        Debug.Log("进入了");
        if(DataManager.Instance.killNumber==1)
        {
            sp2101.Play();
            
        }
        else if(DataManager.Instance.killNumber==2)
        {
            sp2102.Play();
           
        }
        else if(DataManager.Instance.killNumber==3)
        {
            sp2103.Play();
           
        }
        else if(DataManager.Instance.killNumber>=4)
        {
            sp2104.Play();
            
        }
    }

    public void SpeakerHealPlay()
    {
        if(DataManager.Instance.healNumber==1)
        {
            sp2201.Play();
           
        }
        else if(DataManager.Instance.healNumber==2)
        {
            sp2202.Play();
           
        }
        else if(DataManager.Instance.healNumber==3)
        {
            sp2203.Play();
            
        }
        else if(DataManager.Instance.healNumber==4)
        {
            sp2204.Play();
           
        }
    }

    public void SpeakerDialougePlay()
    {
        int randomIndex = Random.Range(0, 4); // 生成一个0到3之间的随机数
        switch(randomIndex)
        {
            case 0:
                sp2301.Play();
                break;
            case 1:
                sp2302.Play();
                break;
            case 2:
                sp2303.Play();
                break;
            case 3:
                sp2304.Play();
                break;
        }
    }

}

