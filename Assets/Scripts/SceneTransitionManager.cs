using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {
    public FadeScreen fadeScreen;

    [SerializeField] ThemeManager themeManager;

    public void GoToSceneAsync() {
        int sceneIndex;

        switch (themeManager.Season)
        {
            case "Spring":
                sceneIndex = 1;
                break;
            case "Summer":
                sceneIndex = 2;
                break;
            case "Autumn":
                sceneIndex = 3;
                break;
            case "Winter":
                sceneIndex = 4;
                break;
            default:
                sceneIndex = 0;
                break;
        }
        
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }

    IEnumerator GoToSceneAsyncRoutine(int sceneIndex) {
        fadeScreen.FadeOut();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= fadeScreen.fadeDuration && !operation.isDone) {
            timer += Time.deltaTime;
            yield return null;
        }
        operation.allowSceneActivation = true;
    }

}
