using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class TransitionPos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FNote;
    private bool playerIsInside;
    public int playerCollideTimes=0;
    public DialogueSpeaker evilSpeaker;
    public DialogueSpeaker goodSpeaker;


    private void Update() 
    {
       
        if(Input.GetKeyDown(KeyCode.F)&&playerIsInside)
        {
            this.GetComponentInChildren<DialogueTreeController>().StartDialogue();
        }

    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            playerIsInside=true;
            if(FNote!=null)
            {
                FNote.SetActive(true);
            }
            playerCollideTimes++;
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            playerIsInside=false;
            if(FNote!=null)
            {
                FNote.SetActive(false);
            }
        }
        
    }

    public void TransToEvil()
    {
        
        TransitionManager.Instance.Transition("TestScene_02_dev","TestScene_BeatDragon_dev");

    }

    public void TransToGood()
    {
        
        TransitionManager.Instance.Transition("TestScene_02_dev","TestScene_dragonDream_dev");

    }
    public void CheckEvil()
    {
        int evilnumber=DataManager.Instance.evilCount;
        if(evilnumber<=2&&DataManager.Instance.isEneteredMemory)
        {
            //TransToGood();
            StartCoroutine("TransToGoodCO");
        }
        else
        {
            //TransToEvil();
            StartCoroutine("TransToEvilCO");
        }
    }


    public IEnumerator TransToEvilCO()
    {
        evilSpeaker.Play();
        yield return new WaitUntil(()=>evilSpeaker.isFinished);
        TransToEvil();   
    }

    public IEnumerator TransToGoodCO()
    {
        goodSpeaker.Play();
        yield return new WaitUntil(()=>goodSpeaker.isFinished);
        TransToGood();
    }

    public void TransToFlyWithDragon()
    {
        TransitionManager.Instance.Transition("TestScene_02_dev","TestScene_FlyWthDragon");
    }

    public void QuitGame()  //退出游戏
    {
        Application.Quit();
    }



    

}
