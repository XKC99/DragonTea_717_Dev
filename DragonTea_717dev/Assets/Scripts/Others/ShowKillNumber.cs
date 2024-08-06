using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKillNumber : MonoBehaviour
{
    public GameObject killNumberImage;
    public Texture kill1;
    public Texture kill2;
    public Texture kill3;
    public Texture kill4;
    public Texture kill5;
    public Texture kill6;

    private void Update() {
        ShowKillNumberImage();
    }
    public void ShowKillNumberImage()
    {
        if(DataManager.Instance.evilCount==0)
        {
            killNumberImage.SetActive(false);
        }
        else if(DataManager.Instance.evilCount>0)
        {
            killNumberImage.SetActive(true);
        }
        
        if(DataManager.Instance.evilCount==1)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill1;
        }
        if(DataManager.Instance.evilCount==2)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill2;
        }
        if(DataManager.Instance.evilCount==3)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill3;
        }
        if(DataManager.Instance.evilCount==4)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill4;
        }
        if(DataManager.Instance.evilCount==5)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill5;
        }
        if(DataManager.Instance.evilCount==6)
        {
            killNumberImage.GetComponent<RawImage>().texture=kill6;
        }
    }

}
