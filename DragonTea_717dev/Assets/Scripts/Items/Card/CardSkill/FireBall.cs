using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=10.0f;
    public Transform FromPlace;
    new private Rigidbody2D rigidbody2D;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetFireSpeed(Vector2 direction)
    {
        rigidbody2D.velocity = direction * speed;
    }

    

   
    
    
    

}
