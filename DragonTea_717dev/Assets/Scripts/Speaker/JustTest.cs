using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustTest : MonoBehaviour
{

    private void OnEnable()
    {
        EventHandler.BoxCollision+=TestBug;
    }
    private void OnDisable()
    {
        EventHandler.BoxCollision-=TestBug;
    }

    private void TestBug()
    {
        Debug.Log("冲个了了了");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
