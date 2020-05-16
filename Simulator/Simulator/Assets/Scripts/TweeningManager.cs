using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweeningManager : MonoBehaviour
{
    public static TweeningManager Instance { get; private set; }

    public List<Curve> curves = new List<Curve>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject); }
    }

    public Curve GetCurve(string key)
    {
        for(int i = 0; i < curves.Count; i++)
        {
            if(curves[i].key == key)
            {
                return curves[i];
            }
        }

        return default;
    }

    public void Animate(GameObject obj, AnimationType type, string curveKey, float duration, float delay)
    {
        AnimationCurve curve = new AnimationCurve();

        if(curveKey != ""){
            curve = GetCurve(curveKey).curve;
        }else{
           curve = AnimationCurve.Linear(0, 0, duration, 1);
        }
       

        AnimationData data = new AnimationData();

        data.duration = duration;

        data.curve = curve;

        data.delay = delay;

        data.type = type;

        switch (type)
        {
            case AnimationType.ScaleIn:
                ScaleIn(obj, data);
                break;
            case AnimationType.ScaleOut:
                ScaleOut(obj, data);
                break;
            case AnimationType.FadeInWithImage:
                FadeIn(obj.GetComponent<Image>(), data);
                break;
            case AnimationType.FadeOutWithImage:
                FadeOut(obj.GetComponent<Image>(), data);
                break;
            case AnimationType.FadeInWithCanvasGroup:
                FadeIn(obj.GetComponent<CanvasGroup>(), data);
                break;
            case AnimationType.FadeOutWithCanvasGroup:
                FadeOut(obj.GetComponent<CanvasGroup>(), data);
                break;
        }
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

    public void FadeOut(CanvasGroup obj, AnimationData data)
    {
        LeanTween.value(1f, 0f, data.duration).setOnUpdate((float val) => { obj.alpha = val; }).setEase(data.curve);
    }

    public void FadeIn(Image obj, AnimationData data)
    {
        float fromAlpha = data.curve.keys[0].value;
        float toAlpha = data.curve.keys[data.curve.length - 1].value;

        LeanTween.value(fromAlpha, toAlpha, data.duration).setOnUpdate((float val) => { obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, val); }).setEase(data.curve);
    }

    public void FadeOut(Image obj, AnimationData data)
    {
        float fromAlpha = 1 - data.curve.keys[0].value;
        float toAlpha = 1 - data.curve.keys[data.curve.length - 1].value;

        LeanTween.value(fromAlpha, toAlpha, data.duration).setOnUpdate((float val) => { obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, val); }).setEase(data.curve);
    }
}

[System.Serializable]
public class AnimationData
{
    public string key = "";
    public AnimationType type;
    public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 0.3f, 1);
    public float duration = 0.3f;
    public float delay = 0f;
}

[System.Serializable]
public class Curve
{
    public string key;
    public AnimationCurve curve;
}

public enum AnimationType
{
    ScaleIn,
    ScaleOut,
    FadeInWithImage,
    FadeOutWithImage,
    FadeInWithCanvasGroup,
    FadeOutWithCanvasGroup
}