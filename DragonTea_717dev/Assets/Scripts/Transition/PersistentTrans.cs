using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentTrans : MonoBehaviour
{
    
    void Start()
    {
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
