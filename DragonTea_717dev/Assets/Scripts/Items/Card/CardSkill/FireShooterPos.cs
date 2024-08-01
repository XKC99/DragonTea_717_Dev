using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooterPos : MonoBehaviour
{
   public bool facingRight;

private void Update()
{
    float moveX = Input.GetAxis("Horizontal");
     if (moveX > 0 && !facingRight)
        {
            PosFlip();
        }
        else if (moveX < 0 && facingRight)
        {
            PosFlip();
        }
        

}

public void PosFlip()
{
    facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
}

}
