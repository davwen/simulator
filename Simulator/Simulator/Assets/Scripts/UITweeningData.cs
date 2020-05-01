using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweeningData : MonoBehaviour
{
    public string animationKey;

    public void ScaleIn()
    {
        TweeningManager.Instance.ScaleIn(gameObject, TweeningManager.Instance.GetAnimation(animationKey));
    }
}
