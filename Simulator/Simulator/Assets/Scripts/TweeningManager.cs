using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweeningManager : MonoBehaviour
{
    public static TweeningManager Instance { get; private set; }

    public List<AnimationData> animations = new List<AnimationData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject); }
    }

    public AnimationData GetAnimation(string key)
    {
        for(int i = 0; i < animations.Count; i++)
        {
            if(animations[i].key == key)
            {
                return animations[i];
            }
        }

        return default;
    }

    public void ScaleIn(GameObject obj, AnimationData data)
    {
        LeanTween.scale(obj, new Vector3(1, 1, 1), data.duration).setDelay(data.delay).setEase(data.curve).setFrom(Vector3.zero);
    }

    public void ScaleOut(GameObject obj, AnimationData data)
    {
        LeanTween.scale(obj, new Vector3(0, 0, 0), data.duration).setDelay(data.delay).setEase(data.curve);
    }

    public void FadeIn(CanvasGroup obj, AnimationData data)
    {
        LeanTween.value(0f, 1f, data.duration).setOnUpdate((float val) => {obj.alpha = val;}).setEase(data.curve);
    }
}

[System.Serializable]
public class AnimationData
{
    public string key = "";
    public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 0.3f, 1);
    public float duration = 0.3f;
    public float delay = 0f;
}