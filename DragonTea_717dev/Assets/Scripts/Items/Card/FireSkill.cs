using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireBallPrefab;
    public Transform fromPos;
    public Vector2 mousePos;
    public Vector2 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Shoot();
    }
    public void Shoot()
    {
        direction=(mousePos-new Vector2(transform.position.x,transform.position.y)).normalized;
        //transform.right=direction;
        if(Input.GetButton("Fire1"))
        {
            GameObject fire=Instantiate(fireBallPrefab,fromPos.position,Quaternion.identity);
            fire.GetComponent<FireBall>().SetFireSpeed(direction);
        }
    }
}
