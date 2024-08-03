using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGravity : MonoBehaviour
{
   public Rigidbody2D rb;
   public float gravityScale;
   public void ResetGravityRb()
   {
        rb.gravityScale=gravityScale;
   }
}
