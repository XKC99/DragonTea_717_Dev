using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToKill : MonoBehaviour
{
    public GameObject fallObject;
    public void killplayer()
    {
        fallObject.SetActive(true);
    }


}
