using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneIndex;

    public void switchScene(float delay){
        StartCoroutine(switchSceneWithDelay(delay));
    }

    private IEnumerator switchSceneWithDelay(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
