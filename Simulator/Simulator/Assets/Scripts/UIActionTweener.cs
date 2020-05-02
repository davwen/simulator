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

    public void Animate()
    {
        TweeningManager.Instance.Animate(gameObject, type, curve, duration, delay);
    }
}

