using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire"||other.gameObject.tag == "Heal")
        {
            SkillBallPool.Instance.PushBallObject(other.gameObject);
        }
    }

}
