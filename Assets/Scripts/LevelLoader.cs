using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;
    [SerializeField] private bool loadWithFade;
    [SerializeField] private CanvasGroup fadeScreen;
    [SerializeField] private float fadeOutTime = 0.2f;
    [SerializeField] private AnimationCurve fadeOutCurve;



    // 调用这个方法来加载场景
    public void LoadScene()
    {
        if (loadWithFade && fadeScreen != null)
        {
            StartCoroutine(LoadSceneAfterFade(sceneNameToLoad));
            return;
        }
        SceneManager.LoadScene(sceneNameToLoad);
    }

    IEnumerator LoadSceneAfterFade(string sceneName)
    {
        float currentTime = 0f;
        while (currentTime < fadeOutTime)
        {
            currentTime += Time.deltaTime;
            float alpha = fadeOutCurve.Evaluate(currentTime / fadeOutTime);
            fadeScreen.alpha = alpha;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}

