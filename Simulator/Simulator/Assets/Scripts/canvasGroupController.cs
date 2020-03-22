using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasGroupController : MonoBehaviour
{
    public CanvasGroup canvasGroup;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(canvasGroup.alpha == 0f)
        {
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.blocksRaycasts = true;
        }
    }
}
