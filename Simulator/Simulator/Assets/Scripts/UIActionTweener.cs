using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionTweener : MonoBehaviour
{
    public AnimationType type;
    public float duration;
    public float delay;
    public string curve;

    [Space(10)]

    public bool playOnStart;

    public void Animate()
    {
        TweeningManager.Instance.Animate(gameObject, type, curve, duration, delay);
    }

    void Start(){
        if(playOnStart){
            Animate();
        }
    }
}

