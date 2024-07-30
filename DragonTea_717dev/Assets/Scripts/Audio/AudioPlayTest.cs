using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayTest : MonoBehaviour
{
    public string AudioName;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioManager.instance.Play(AudioName);
            Debug.Log("放音乐");
            this.gameObject.SetActive(false);
            
        }
    }

    
}
