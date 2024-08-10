using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeacialBox : ItemLogic,ICardAffected,IShowF
{
    public GameObject FNote;
    private bool playerIsInside;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)&&playerIsInside)
        {
            SpeacialBoxGetCard();
        }

    }

    public override bool Execute(Card card) 
    {
        switch(card.cardType)
        {
            case CardType.Fire:
            case CardType.Heal:
            case CardType.Fly:
            case CardType.Fall:
                //CannotUesCardOnThis();
                return false;
        }
        return false;
    }

    public void HideF()
    {
        FNote.SetActive(false);

    }

    public void ShowF()
    {
        FNote.SetActive(true);

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteTure(this);
                break;
            case "Player":
                //FNote=other.transform.Find("Canvas").gameObject;
                playerIsInside=true;
                FNote.SetActive(true);
                break;
        }
        
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Card":
                other.gameObject.GetComponent<CardHandler>().SetExcuteFalse(this);
                break;
            case "Player":
                playerIsInside=false;
                FNote.SetActive(false);
                break;
        }

    }

    public void SpeacialBoxGetCard()
    {
        this.GetComponent<CardTrigger>().PlayerGetCard();
        this.GetComponent<CardTrigger>().CardIsGot();
        this.GetComponent<CardTrigger>().GotTimesAdd();

    }

   

    

    
}
