using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesListManager : MonoBehaviour
{
    public List<SpawnableObj> availableObjects;

    public ListCreator listCreator;

    
    void Start()
    {
        UpdateList();

        ModeManager.Instance.onModeChange += delegate
        {
            switch (ModeManager.Instance.currentMode)
            {
                case ModeManager.MODE_SPAWN:
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
                    break;

                case ModeManager.MODE_EDIT:
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleOut, "linear", 0.3f, 0f);
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeOutWithCanvasGroup, "linear", 0.1f, 0f);
                    break;
            }
        };
    }

    void UpdateList(){
        ListAdapter adapter = new SpritesListAdapter(availableObjects);

        listCreator.UpdateAll(adapter);
    }
}
