using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseUI : MonoBehaviour
{
    public Text pauseText;

    public ObjectManager objectManager;

    public string pausedLabel;

    public string runningLabel;

    void Start()
    {
        
    }


    void Update()
    {
        switch (objectManager.isRunning)
        {
            case true:
                pauseText.text = runningLabel;
                break;

            case false:
                pauseText.text = pausedLabel;
                break;
        }
    }
}
