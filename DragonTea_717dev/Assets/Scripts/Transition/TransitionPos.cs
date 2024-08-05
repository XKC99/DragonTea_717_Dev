using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class TransitionPos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FNote;
    private bool playerIsInside;

    

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
            FNote.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            playerIsInside=false;
            FNote.SetActive(false);
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
            TransToGood();
        }
        else
        {
            TransToEvil();
        }
    }

    public void TransToFlyWithDragon()
    {
        TransitionManager.Instance.Transition("TestScene_02_dev","TestScene_FlyWthDragon");
    }

}
