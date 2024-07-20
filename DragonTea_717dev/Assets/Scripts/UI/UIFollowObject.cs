using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowObject : MonoBehaviour
{
    public Transform target; // 需要跟随的物体
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (target!= null)
        {
            rectTransform.position = target.position;
        }
    }
}
