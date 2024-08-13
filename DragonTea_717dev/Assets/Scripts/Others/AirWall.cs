using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AirWall : MonoBehaviour
{
    public UnityEvent OnCollideWall;
    public UnityEvent OnBengHuai;
    public GameObject PostVolme;

    public int bengHuaiNumber;

    public int collideNumber;

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     COllideWall();
    // }
    private void Update()
    {
        if (collideNumber >= bengHuaiNumber)
        {
           OnBengHuai?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PostVolme.SetActive(true);
        COllideWall();
        collideNumber++;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        PostVolme.SetActive(false);
    }

    public void COllideWall()
    {
        OnCollideWall?.Invoke();
    }

    public void CollideSound()
    {
        AudioManager.Instance.PlayOneShot("smagicwarn");
    }

    

   
}
