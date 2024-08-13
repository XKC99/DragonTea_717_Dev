using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfHaveLava : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lava;
    public DialogueSpeaker begin;
    public DialogueSpeaker hasLava;
    public DialogueSpeaker noLava;
    void Start()
    {
        begin.Play();
        if(DataManager.Instance.isDestroyeLava)
        {
            lava.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogueAboutLava()
    {
        if(DataManager.Instance.isDestroyeLava)
        {
            noLava.Play();
        }
        else
        {
            hasLava.Play();
        }
    }
}
