using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAsNPC : MonoBehaviour
{
    
    public void DragonDespear()
    {
        this.gameObject.SetActive(false);
    }

    public void DragonDead()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Dead",true);
    }

}
