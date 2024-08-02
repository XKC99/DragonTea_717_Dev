using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePost : MonoBehaviour
{
    public GameObject post;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            post.SetActive(false);
        }
    }
}
