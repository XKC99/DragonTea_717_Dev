using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=10.0f;
    public float time;
    public Transform FromPlace;
    new private Rigidbody2D rigidbody2D;
    private float duration;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        duration = 0;
    }
    
    void Update()
    {
        duration += Time.deltaTime;
        if (duration >= time)
        {
            SkillBallPool.Instance.PushBallObject(gameObject);
        }
    }

    void OnDisable()
    {
        rigidbody2D.velocity = Vector2.zero;
    }

    public void SetFireSpeed(Vector2 direction)
    {
        rigidbody2D.velocity = direction * speed;
    }

    

   
    
    
    

}
