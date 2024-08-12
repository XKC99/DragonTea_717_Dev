using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MagicStone : MonoBehaviour
{
    public GameObject humanPlayer;
    public GameObject dragonPlayer;
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera dragonCamera;

    public List<GameObject> otherFalseThings;
    public void ChangeToDragon()
    {
        dragonPlayer.transform.position=humanPlayer.transform.position;
        humanPlayer.SetActive(false);
        dragonPlayer.SetActive(true);
        //mainVirtualCamera.Follow = dragonPlayer.transform;
        playerCamera.gameObject.SetActive(false);
        dragonCamera.gameObject.SetActive(true);
        dragonCamera.Follow = dragonPlayer.transform;
        OtherFalse();
    }

    public void BackToHuman()
    {
        humanPlayer.transform.position = dragonPlayer.transform.position;
        dragonPlayer.SetActive(false);
        humanPlayer.SetActive(true);
        dragonCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        playerCamera.Follow = humanPlayer.transform;
        OtherTrue();
    }

    public void OtherFalse()
    {
        foreach (var item in otherFalseThings)
        {
            item.SetActive(false);
        }
    }

    public void OtherTrue()
    {
        foreach (var item in otherFalseThings)
        {
            item.SetActive(true);
        }
    }
}
