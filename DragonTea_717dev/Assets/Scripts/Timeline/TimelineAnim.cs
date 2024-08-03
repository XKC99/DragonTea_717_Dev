using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAnim : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
   public void ChangeAnimTypeToAttack()
   {
      animator.SetBool("Attack", true);
   }

   public void gameObjectSetFalse()

   {
    this.gameObject.SetActive(false);

   }

   public void gameObjectSetTrue()
   {
    this.gameObject.SetActive(true);
   }
   
}
