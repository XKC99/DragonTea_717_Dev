using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGameAffect : MonoBehaviour
{
    public GameObject erropic;
    

    public void PauseGame()
    {
        //AudioManager.Instance.PlayOneShot("sxinhao");
        StartCoroutine("TurnDownGame");
        //Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator TurnDownGame()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);  
        erropic.SetActive(true);
        yield return new WaitForSecondsRealtime(2);  
        QuitGame();
    }

}
