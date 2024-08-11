using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    //public bool isGetEggkey;

    public void GetEggkey()
    {
        DataManager.Instance.isGetEggkey = true;
    }

    public bool GetEggkeyBool()
    {
        if(DataManager.Instance.isGetEggkey == true)
        {
            return true;
        }
        else
        {
            return false;
        }     
    }

}
